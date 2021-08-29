using Grpc.Net.Client;
using grpc4InRowService.Protos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace connectFour
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Game : Window
    {
        private int[,] board;
        private int turn, p1_cellCount, p2_cellCount, p1_score, p2_score, id1, id2, lastIndex;
        private List<Image> imgs;
        private bool isMyTurn, hasAnimationFinished;
        private GrpcChannel channel;
        private Games.GamesClient gameClient;
        private User.UserClient userClient;
        private Timer timer;

        public Game(bool isMyTurn, int id1, int id2)
        {
            InitializeComponent();
            initVars(isMyTurn, id1, id2);

            /* if (!isMyTurn)
             {
                 /*  Application.Current.Dispatcher.Invoke((Action)delegate {
                       makeOpponentsMove(getOpponentsMove());
                   });*/
            /* Thread t = new Thread(() =>
                 {
                     makeOpponentsMove(getOpponentsMove()); // TODO: UNIMPLEMENTED!!! (should not be called more than once)
                 });
             t.SetApartmentState(ApartmentState.STA);
             t.Start();
         }*/
        }

        private void initVars(bool isMyTurn, int id1, int id2)
        {
            board = new int[7, 6];
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); board[i, j++] = 0) ; // init empty board

            //initiate default values
            p1_cellCount = 0;
            p2_cellCount = 0;
            p1_score = 0;
            p2_score = 0;
            turn = 0;
            imgs = new List<Image>();
            this.isMyTurn = isMyTurn;
            channel = GrpcChannel.ForAddress("https://localhost:5001");
            gameClient = new Games.GamesClient(channel);
            userClient = new User.UserClient(channel);
            this.id1 = id1;
            this.id2 = id2;
            lastIndex = -1;
            hasAnimationFinished = true;
            turnTitle.Text = isMyTurn ? "Your Turn" : "Opponent's Turn";  // update turn title view
            turnTitle.Foreground = isMyTurn ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Colors.Yellow);

            if (!isMyTurn)
            { // check for oponent's first move iff your are the not the initator of the game (= it's not your turn at the start)
                hasAnimationFinished = false;
                timer = new Timer();
                timer.Tick += new EventHandler(timer_Tick);
                timer.Interval = 200; // listen and update after 1/5 of a second (for the consturtor to finished)
                timer.Start();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            makeOpponentsMove();
            timer.Stop();
            timer.Dispose();
            hasAnimationFinished = true;
        }

        private async void OnPreviewMouseLeftButtonDownAsync(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!hasAnimationFinished)
                return;

            if (!isMyTurn || checkForWinnerOrTie() != 0) // if game over or it's not my turn than ignore the click
                return;
            //boardView.IsHitTestVisible = false;
            hasAnimationFinished = false;
            var point = Mouse.GetPosition(boardView); // mouse ptr cordiante at click event time

            int row = 0, col = 0;
            double accumulatedHeight = 0, accumulatedWidth = 0;

            // calc row mouse was over
            foreach (var rowDefinition in boardView.RowDefinitions)
            {
                accumulatedHeight += rowDefinition.ActualHeight;
                if (accumulatedHeight >= point.Y)
                    break;
                row++;
            }

            // calc col mouse was over
            foreach (var columnDefinition in boardView.ColumnDefinitions)
            {
                accumulatedWidth += columnDefinition.ActualWidth;
                if (accumulatedWidth >= point.X)
                    break;
                col++;
            }

            Reply call = await gameClient.MakeMoveAsync(new MoveRequest { Move = col, InitiatorID = id1, InitiatedID = id2 });

            int emptyCell_row = findEmptyRowCell(col - 2);
            if (emptyCell_row == -1)
            {
                boardView.IsHitTestVisible = false;
                return;
            }
            updateBoard(emptyCell_row, col - 2); // update 2D board + make animation of sliding ball
            //boardView.IsHitTestVisible = false;
        }

        private void codeAfterAnimation()
        {
            p1_cellCount = turn == 0 ? p1_cellCount + 1 : p1_cellCount;
            p2_cellCount = turn == 1 ? p2_cellCount + 1 : p2_cellCount;
            turn = 1 - turn;
            isMyTurn = !isMyTurn;

            int winnerOrTie = checkForWinnerOrTie();
            if (winnerOrTie != 0) // val!=0 => winner or tie
            {
                if (winnerOrTie == 1) // first player won - RED
                {
                    p1_score += 1000;
                    p2_score += p2_cellCount * 10;
                }
                else if (winnerOrTie == 2) // second player won - YELLOW
                {
                    p2_score += 1000;
                    p1_score += p1_cellCount * 10;
                }
                else if (winnerOrTie == 3) // tie
                {
                    p1_score += p1_cellCount * 10;
                    p2_score += p2_cellCount * 10;
                }
                updateBonus();
                p1Score.Text = "" + p1_score;
                p2Score.Text = "" + p2_score;

                winner_tie_msgBoxAsync(winnerOrTie);
            }
        }

        private void makeAnimation(int emptyCell_row, int col)
        {
            Image img = new Image { Width = 70, Height = 70 }, img2;
            BitmapImage bitmapImage;
            String path = Environment.CurrentDirectory.Split("connectFour")[0] + "connectFour\\Resources\\"; // current project dir.

            // update board with relevant cell (red/yellow ball)
            if (turn == 0)
                bitmapImage = new BitmapImage(new Uri(path + "pred.png"));
            else
                bitmapImage = new BitmapImage(new Uri(path + "pyellow.png"));

            img.Source = bitmapImage;


            //update the image/ball uppon the board
            img.SetValue(Grid.RowProperty, 1);
            img.SetValue(Grid.ColumnProperty, col + 2);
            boardView.Children.Add(img);

            for (int i = 1; i <= board.GetLength(0); i++)
            {// make new images of the board cells on top of the ball animation
                img2 = new Image { Width = 70, Height = 70 };
                img2.Source = new BitmapImage(new Uri(path + "cell_hole.png"));
                img2.SetValue(Grid.RowProperty, i);
                img2.SetValue(Grid.ColumnProperty, col + 2);
                boardView.Children.Add(img2);
                imgs.Add(img2);
            }
            imgs.Add(img);

            // make animation of the ball sliding down
            Vector offset = VisualTreeHelper.GetOffset(img);
            var top = offset.Y;
            var left = offset.X;
            TranslateTransform trans = new TranslateTransform();
            img.RenderTransform = trans;
            int posY = emptyCell_row == 6 ? 60 : emptyCell_row == 5 ? 58 : emptyCell_row == 4 ? 56 : emptyCell_row == 3 ? 52 : emptyCell_row == 2 ? 46
                : emptyCell_row == 1 ? 35 : 0;

            DoubleAnimation animY = new DoubleAnimation(0, posY * (emptyCell_row + 1) - top, TimeSpan.FromMilliseconds(900 - (6 - emptyCell_row) * 100));

            EventHandler onComplete = (s, e) =>
            {
                codeAfterAnimation(); // check for winner + update score etc
                                      //boardView.IsHitTestVisible = true; // enable mouse clicks again for next move
                hasAnimationFinished = true;
                turnTitle.Text = isMyTurn ? "Your Turn" : "Opponent's Turn";  // update turn title view
                turnTitle.Foreground = isMyTurn ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Colors.Yellow);
                makeOpponentsMove();
            };
            animY.Completed += onComplete;
            trans.BeginAnimation(TranslateTransform.YProperty, animY);
        }

        private void updateBoard(int emptyCell_row, int col)
        {
            // update the 2D board programically
            board[emptyCell_row, col] = turn + 1;

            makeAnimation(emptyCell_row, col);
        }

        private int findEmptyRowCell(int j)
        {
            for (int i = board.GetLength(0) - 1; i >= 0; i--) // find the position of the ball by the user col. input
                if (board[i, j] == 0)
                    return i;
            return -1; // return -1 if all col is full
        }

        private int checkForWinnerOrTie()
        {
            bool isTie = true;
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (checkDown(i, j)) // check 4 balls down from start position (i,j)
                    {
                        updateBoardWinner(i, j, 0); // 0 = down
                        return board[i, j]; // return winner
                    }
                    else if (checkRight(i, j)) // check 4 balls right from start position (i,j)
                    {
                        updateBoardWinner(i, j, 1); // 1 = right
                        return board[i, j]; // return winner

                    }
                    else if (checkMainDiagonal(i, j)) // check 4 balls diagnoally from start position (i,j)
                    {
                        updateBoardWinner(i, j, 2); // 2 = main diagonal
                        return board[i, j]; //  return winner
                    }
                    else if (checkSecondaryDiagonal(i, j)) // check 4 balls 2nd diagonally from start position (i,j)
                    {
                        updateBoardWinner(i, j, 3); // 3 = second diagonal
                        return board[i, j]; // return winner
                    }

                    if (board[i, j] == 0) // check for empty cell on board, if there isn't => tie
                        isTie = false; // if there is even 1 empty cell -> not a tie (in current time/move)
                }
            return isTie ? 3 : 0; // 3=tie, no winner=0
        }

        private bool checkDown(int i, int j)
        { // check 4 balls down from start position (i,j)
            try
            {
                return board[i, j] != 0 &&
                    board[i, j] == board[i + 1, j] && board[i, j] == board[i + 2, j] && board[i, j] == board[i + 3, j];
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }
        private bool checkRight(int i, int j)
        {// check 4 balls right from start position (i,j)
            try
            {
                return board[i, j] != 0 &&
                    board[i, j] == board[i, j + 1] && board[i, j] == board[i, j + 2] && board[i, j] == board[i, j + 3];
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }
        private bool checkMainDiagonal(int i, int j)
        {// check 4 balls diagonally from start position (i,j)
            try
            {
                return board[i, j] != 0 &&
                    board[i, j] == board[i + 1, j + 1] && board[i, j] == board[i + 2, j + 2] && board[i, j] == board[i + 3, j + 3];
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }
        private bool checkSecondaryDiagonal(int i, int j)
        {// check 4 balls 2nd diagonally from start position (i,j)
            try
            {
                return board[i, j] != 0 &&
                    board[i, j] == board[i + 1, j - 1] && board[i, j] == board[i + 2, j - 2] && board[i, j] == board[i + 3, j - 3];
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        private void updateBoardWinner(int i, int j, int direction)
        {
            BitmapImage bitmapImage;
            String path = Environment.CurrentDirectory.Split("connectFour")[0] + "connectFour\\Resources\\";

            if (board[i, j] == 1) // RED
                bitmapImage = new BitmapImage(new Uri(path + "predMarked.png"));
            else // board[i,j]==2 - YELLOW
                bitmapImage = new BitmapImage(new Uri(path + "pyellowMarked.png"));


            for (int k = 0; k < 4; k++) // update winner , 4 cells on board with crowned/marked balls
            {
                Image img = new Image { Width = 70, Height = 70 };
                img.Source = bitmapImage;

                // add crowned ball image
                img.SetValue(Grid.RowProperty, i + 1);
                img.SetValue(Grid.ColumnProperty, j + 2);
                boardView.Children.Add(img);
                imgs.Add(img);

                if (direction == 0) //down
                    i++;
                else if (direction == 1) //right
                    j++;
                else if (direction == 2) //main diagonal
                {
                    i++;
                    j++;
                }
                else // 3 = second diagonal
                {
                    i++;
                    j--;
                }
            }
        }

        private async void winner_tie_msgBoxAsync(int p)
        {
            String msg;

            if (p == 1)
                msg = "Red Player Has Won! ☺\nWould you like to have another round?";
            else if (p == 2)
                msg = "Yellow Player Has Won! ☺\nWould you like to have another round?";
            else msg = "It's a Tie! ☻\nWould you like to have another round?";
            Reply r;
            if (id1 == LoginPage.myID)
                r = await gameClient.UpdateScoreAsync(new Score { Key1 = id1, Key2 = id2, Score1 = p1_score, Score2 = p2_score, Won = p });//CHECK + need to add field Won = ??
            //TODO: Update server with game stats (game turned to finished, player points, etc..

            new System.Threading.Thread(async () =>
            {// new thread in order for the game to freeze until the answer is given (another round/exit)               
                if (anotherRoundAnswer(msg) && anotherRoundOpponentsAnswer()) // play another round iff 2 players agreed
                    this.Dispatcher.Invoke(() => // in order to change the UI with another thread
                    {
                        resetBoard(); // reset board to start another round
                    });
                else // if the answer was to quit the game
                {
                    await userClient.AddToOnlineAsync(new GeneralReq { Id = LoginPage.myID, Username = LoginPage.myUsername });
                    this.Close(); // close the game window
                }
            }).Start();
        }
        private void updateBonus()
        {
            //check for bonus of a player with ball in each col.
            bool isBonus_p1 = true, isBonus_p2 = true;
            for (int j = 0; j < board.GetLength(1); j++)
            {
                isBonus_p1 = checkCol(j, 1) && isBonus_p1;
                isBonus_p2 = checkCol(j, 2) && isBonus_p2;
            }
            // bonus +100 to score
            p1_score = isBonus_p1 ? p1_score + 100 : p1_score;
            p2_score = isBonus_p2 ? p2_score + 100 : p2_score;
        }
        private bool checkCol(int j, int p)
        {
            // check current col. if it has a cell/ball of player p
            for (int i = 0; i < board.GetLength(0); i++)
                if (board[i, j] == p)
                    return true;
            return false;
        }

        private void resetBoard()
        { // reset board view to default/empty/start
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); board[i, j++] = 0) ;

            foreach (Image img in imgs)
                boardView.Children.Remove(img);
            imgs.Clear();
        }

        private async void makeOpponentsMove()
        {
            Reply call;
            while (true)
            {
                call = await gameClient.CheckMoveAsync(new MoveCheck { InitiatorID = id1, InitiatedID = id2 });
                if (call.Answer && call.Move.Id != LoginPage.myID && lastIndex != call.Move.Index)
                    break;
                //else Thread.Sleep(1000);
            }
            lastIndex = call.Move.Index;
            int emptyCell_row = findEmptyRowCell(call.Move.Move_ - 2);
            if (emptyCell_row == -1)
                return;
            updateBoard(emptyCell_row, call.Move.Move_ - 2); // update 2D board + make animation of sliding ball
        }

        private bool anotherRoundAnswer(String msg)
        {
            //TODO: when game finished, a pop msg appears along with a question to both users about playing another round
            MessageBoxResult answer = System.Windows.MessageBox.Show(msg, "Game Over",
                    MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);

            //Here: The answer should be sent to the server
            // ...

            return answer == MessageBoxResult.Yes; // return true iff accepted another round, else return false
        }
        private bool anotherRoundOpponentsAnswer()
        {
            //TODO: when game finished, a pop msg appears along with a question to both users about playing another round
            //In this method we will wait for the answer of the opponent 
            // if and only if both users accepted another round - another round will be initialized with server implemtations

            return false; // return true iff the opponenet accepted another round, else return false
        }

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            //TODO: sign out of the current user and update online users list in the server
            //send a msg to to the other opponent of it's disconnection
        }
    }
}

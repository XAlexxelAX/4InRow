using Grpc.Net.Client;
using grpc4InRowService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
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
    public partial class MainWindow : Window
    {
        private int[,] board;
        private int turn, p1_cellCount, p2_cellCount, p1_score, p2_score;
        private List<Image> imgs;
        public MainWindow()
        {
            InitializeComponent();
            initVars();
        }

        private void initVars()
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
        }

        private void OnPreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            //  boardView.IsHitTestVisibleProperty = false;
            /*if (e.ClickCount == 2) // for double-click, remove this condition if only want single click
            {*/

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

            int emptyCell_row = findEmptyRowCell(col - 2);
            if (emptyCell_row == -1)
                return;

            updateBoard(emptyCell_row, col - 2); // update 2D board + make animation of sliding ball

            // row and col now correspond Grid's RowDefinition and ColumnDefinition mouse was 
            // over when double clicked!
            //}
        }

        private void codeAfterAnimation()
        {
            p1_cellCount = turn == 0 ? p1_cellCount + 1 : p1_cellCount;
            p2_cellCount = turn == 1 ? p2_cellCount + 1 : p2_cellCount;
            turn = 1 - turn;

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

                if (winner_tie_msgBox(winnerOrTie) == MessageBoxResult.Yes) // player want another round
                    resetBoard();
                else // player wished to exit
                    Environment.Exit(0);
            }
        }

        private void makeAnimation(int emptyCell_row, int col)
        {
            boardView.IsHitTestVisible = false; // disable mouse clicks again until full move and animation is over
            var img = new Image { Width = 70, Height = 70 };
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
            imgs.Add(img);

            // make animation of the ball sliding down
            Vector offset = VisualTreeHelper.GetOffset(img);
            var top = offset.Y;
            var left = offset.X;
            TranslateTransform trans = new TranslateTransform();
            img.RenderTransform = trans;
            int posY = emptyCell_row == 6 ? 60 : emptyCell_row == 5 ? 58 : emptyCell_row == 4 ? 56 : emptyCell_row == 3 ? 52 : emptyCell_row == 2 ? 46
                : emptyCell_row == 1 ? 35 : 0;

            DoubleAnimation animY = new DoubleAnimation(0, posY * (emptyCell_row + 1) - top, TimeSpan.FromMilliseconds(1500 - (6 - emptyCell_row) * 200));

            EventHandler onComplete = (s, e) =>
            {
                // animY.Completed -= onComplete;
                codeAfterAnimation(); // check for winner + update score etc
                boardView.IsHitTestVisible = true; // enable mouse clicks again for next move
            };
            animY.Completed += onComplete;
            trans.BeginAnimation(TranslateTransform.YProperty, animY);
        }

        private async Task updateBoard(int emptyCell_row, int col)
        {

            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new User.UserClient(channel);
            LoginReply reply = await client.LoginAsync(new LoginRequest());
            if (reply.IsSuccessfull) { MessageBox.Show("I've connected."); }
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
        private MessageBoxResult winner_tie_msgBox(int p)
        {
            if (p == 1)
                return MessageBox.Show("Red Player Has Won! ☺\nWould you like to have another round?", "Game Over",
                       MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            else if (p == 2)
                return MessageBox.Show("Yellow Player Has Won! ☺\nWould you like to have another round?", "Game Over",
                       MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);

            return MessageBox.Show("It's a Tie! ☻\nWould you like to have another round?", "Game Over",
                   MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
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
    }
}

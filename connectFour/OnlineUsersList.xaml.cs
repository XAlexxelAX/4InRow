using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using Grpc.Core;
using Grpc.Net.Client;
using grpc4InRowService.Protos;

namespace connectFour
{
    /// <summary>
    /// Interaction logic for OnlineUsersList.xaml
    /// </summary>
    public partial class OnlineUsersList : Window
    {
        private GrpcChannel channel;
        private User.UserClient userClient;
        private Games.GamesClient gameClient;
        private Timer timer;
        private bool isFree;
        private ListBoxItem lbi;
        private int timerCount;
        public OnlineUsersList()
        {
            InitializeComponent();

            channel = GrpcChannel.ForAddress("https://localhost:5001");
            userClient = new User.UserClient(channel);
            isFree = true;
            timerCount = 0;

            fillListAsync();
            InitTimer();
        }

        public void InitTimer()
        { // timer invokes each second
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 1000; // listen and update each second
            timer.Start();
        }

        public void InitTimer2()
        { // timer invokes each second
            Timer timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick2);
            timer.Interval = 1000; // listen and update each second
            timer.Start();

            if (timerCount == 10)
            {
                timer.Stop();
                timerCount = 0;
            }
        }

        private async void timer_Tick(object sender, EventArgs e)
        {
            //users.Items.Clear();
            fillListAsync();

            //if(isFree)
            CheckReply cr = await gameClient.CheckForGameAsync(new Check
            {
                Id1 = LoginPage.myID
            });

            if (cr.Answer) // if there exist a request for game
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("New Request Incoming!\nDo you want to play?\nYou have 10 seconds to answer...", "New Game?",
                    MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                GameRequest gr = new GameRequest
                {
                    MyId = (int)lbi.DataContext,
                    OpponentID = LoginPage.myID
                };
                if (result == MessageBoxResult.Yes)
                {
                    gr.Answer = AnswerCode.Accepted;
                    new Game().Show();
                }
                else
                {
                    gr.Answer = AnswerCode.Rejected;
                }
                await gameClient.OfferGameAsync(gr);
            }
        }
        private async void timer_Tick2(object sender, EventArgs e)
        { // check for answer/response of the game offer
            timerCount++;


        }
        private async Task fillListAsync()
        {
            using (var call = userClient.getOnlineUsers(new GeneralReq()))
            {
                while (await call.ResponseStream.MoveNext())
                {
                    bool isUserExist = false;
                    foreach (ListBoxItem user in users.Items)
                        if (user.Content.Equals(call.ResponseStream.Current.Username))
                        {
                            isUserExist = true;
                            break;
                        }
                    if (!isUserExist)
                    {
                        ListBoxItem newUser = new ListBoxItem();
                        newUser.Content = call.ResponseStream.Current.Username;
                        newUser.DataContext = call.ResponseStream.Current.Id;
                        users.Items.Add(newUser);
                    }
                    // TODO: remove user if he disconnected
                }
            }
        }

        private async void userSelected(object sender, SelectionChangedEventArgs e)
        {
            isFree = false;
            lbi = ((sender as System.Windows.Controls.ListBox).SelectedItem as ListBoxItem);
            //System.Windows.MessageBox.Show("You selected " + lbi.Content.ToString() + ".");
            GameReply gr = await gameClient.OfferGameAsync(new GameRequest
            {
                MyId = LoginPage.myID,
                OpponentID = (int)lbi.DataContext,
                Answer = AnswerCode.Unanswered
            });
            AutoClosingMessageBox.Show("10 seconds until closing...", "Waiting for Opponenet's response", 10000);
            InitTimer2(); // invoke and check for answer

            isFree = true;
        }

        private void dataSearch(object sender, RoutedEventArgs e)
        {
            new DataSearch().Show();
        }
    }
}

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
        private ListBoxItem lbi;
        private Timer timerResponse;
        private int timerCount;
        public OnlineUsersList()
        {
            InitializeComponent();

            channel = GrpcChannel.ForAddress("https://localhost:5001");
            userClient = new User.UserClient(channel);
            gameClient = new Games.GamesClient(channel);

            timerCount = 0;

            fillListAsync();
            InitTimer();
        }

        public void InitTimer()
        { // timer invokes each second
            Timer timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 1000; // listen and update each second
            timer.Start();
        }

        public void InitTimer2()
        { // timer invokes each second
            timerResponse = new Timer();
            timerResponse.Tick += new EventHandler(timer_Tick2);
            timerResponse.Interval = 1000; // listen and update each second
            timerResponse.Start();
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
                var result = AutoClosingMessageBox.Show(
                    text: "Do you want to play?\nYou have 10 seconds to answer...",
                    caption: LoginPage.myUsername + "- New Request Incoming!",
                    timeout: 9000,
                    buttons: MessageBoxButtons.YesNo,
                    defaultResult: new DialogResult());
                GameRequest gr = new GameRequest
                {
                    MyId = (int)lbi.DataContext,
                    OpponentID = LoginPage.myID
                };
                if (result == System.Windows.Forms.DialogResult.Yes)
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
        
        private async Task fillListAsync()
        {
            using (var call = userClient.getOnlineUsers(new GeneralReq()))
            {
                while (await call.ResponseStream.MoveNext())
                {
                    if (call.ResponseStream.Current.Username.Equals(LoginPage.myUsername)) // skip 'my own' (this logged in user) username
                        continue;

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
            lbi = ((sender as System.Windows.Controls.ListBox).SelectedItem as ListBoxItem);
            //System.Windows.MessageBox.Show("You selected " + lbi.Content.ToString() + ".");
            GameReply gr = await gameClient.OfferGameAsync(new GameRequest
            {
                MyId = LoginPage.myID,
                OpponentID = (int)lbi.DataContext,
                Answer = AnswerCode.Unanswered
            });
            AutoClosingMessageBox.Show("10 seconds until closing...", LoginPage.myUsername + "- Waiting for Opponenet's response", 10000);
            InitTimer2(); // invoke and check for answer

        }

        private void dataSearch(object sender, RoutedEventArgs e)
        {
            new DataSearch().Show();
        }
    }
}

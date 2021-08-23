using System;
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
        public OnlineUsersList()
        {
            InitializeComponent();

            channel = GrpcChannel.ForAddress("https://localhost:5001");
            userClient = new User.UserClient(channel);
            isFree = true;

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

        private void timer_Tick(object sender, EventArgs e)
        {
            //users.Items.Clear();
            fillListAsync();

            //if(isFree)
            // TODO: check for incoming request to play a game
        }
        private async System.Threading.Tasks.Task fillListAsync()
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
                        users.Items.Add(newUser);
                    }
                    // TODO: remove user if he disconnected
                }
            }
        }

        private void userSelected(object sender, SelectionChangedEventArgs e)
        {
            isFree = false;
            ListBoxItem lbi = ((sender as System.Windows.Controls.ListBox).SelectedItem as ListBoxItem);
            System.Windows.MessageBox.Show("You selected " + lbi.Content.ToString() + ".");

         /*   using (var call = gameClient.OfferGame(new GameRequest()))
            {
                while (await call.ResponseStream.MoveNext())
                {
                }
            }*/

            isFree = true;
        }
    }
}

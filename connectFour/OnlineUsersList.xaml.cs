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
        private Timer timer;

        public OnlineUsersList()
        {
            InitializeComponent();

            channel = GrpcChannel.ForAddress("https://localhost:5001");
            userClient = new User.UserClient(channel);

            fillListAsync();
            InitTimer();
        }

        public void InitTimer()
        {
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 1000; // listen and update each second
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //users.Items.Clear();
            fillListAsync();
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
            ListBoxItem lbi = ((sender as System.Windows.Controls.ListBox).SelectedItem as ListBoxItem);
            System.Windows.MessageBox.Show("You selected " + lbi.Content.ToString() + ".");
        }
    }
}

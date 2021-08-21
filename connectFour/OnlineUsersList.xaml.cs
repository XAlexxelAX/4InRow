using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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
        public OnlineUsersList()
        {
            InitializeComponent();

            channel = GrpcChannel.ForAddress("https://localhost:5001");
            userClient = new User.UserClient(channel);

            fillListAsync();
        }

        private async System.Threading.Tasks.Task fillListAsync()
        {
            using (var call=userClient.getOnlineUsers(new Req()))
            {
                while(await call.ResponseStream.MoveNext())
                {
                    ListBoxItem newUser = new ListBoxItem();
                    newUser.Content = call.ResponseStream.Current.Username;
                    users.Items.Add(newUser);
                }
            }
        }

        private void userSelected(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            MessageBox.Show("You selected " + lbi.Content.ToString() + ".");
        }
    }
}

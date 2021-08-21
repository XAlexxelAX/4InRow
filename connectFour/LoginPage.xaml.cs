using Grpc.Net.Client;
using grpc4InRowService.Protos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace connectFour
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        private GrpcChannel channel;
        private User.UserClient userClient;

        public LoginPage()
        {
            InitializeComponent();

            channel = GrpcChannel.ForAddress("https://localhost:5001");
            userClient = new User.UserClient(channel);
        }

        private async void login_Click(object sender, RoutedEventArgs e)
        {
            if (username.Text.Equals("")) // check the input (username&password)
                MessageBox.Show("Username is empty!", "Input Error",
                                    MessageBoxButton.OK, MessageBoxImage.Question, MessageBoxResult.OK);
            else if (password.Password.Equals(""))
                MessageBox.Show("Password is empty!", "Input Error",
                                    MessageBoxButton.OK, MessageBoxImage.Question, MessageBoxResult.OK);
            else
            {
                if(!(await userClient.LoginAsync(new LoginRequest { Username = username.Text, Pw = password.Password })).IsSuccessfull)
                {
                    MessageBox.Show("Couldn't login :(");
                    return;
                }
                new OnlineUsersList().Show(); // open the list of current active players

                this.Close();
                
            }
        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            new Register().Show(); // open the list of current active players
        }
    }
}

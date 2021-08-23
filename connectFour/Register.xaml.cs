using Grpc.Net.Client;
using grpc4InRowService.Protos;
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

namespace connectFour
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private GrpcChannel channel;
        private User.UserClient userClient;
        public Register()
        {
            InitializeComponent();
            channel = GrpcChannel.ForAddress("https://localhost:5001");
            userClient = new User.UserClient(channel);
        }

        private async void register_Click(object sender, RoutedEventArgs e)
        {
            if (username.Text.Equals("")) // check the input (username&password)
                MessageBox.Show("Username is empty!", "Input Error",
                                    MessageBoxButton.OK, MessageBoxImage.Question, MessageBoxResult.OK);
            else if (password.Password.Equals(""))
                MessageBox.Show("Password is empty!", "Input Error",
                                    MessageBoxButton.OK, MessageBoxImage.Question, MessageBoxResult.OK);
            else
            {
                var response = await userClient.RegisterAsync(new UserRequest { Username = username.Text, Pw = password.Password });
                if (!response.IsSuccessfull)
                {
                    MessageBox.Show("Couldn't Register :(");
                    return;
                }
                // TODO: ADD USER TO DB

                this.Close();
            }
        }
    }
}

using Grpc.Core;
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
        public static int myID;
        public static String myUsername;
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
                GeneralReply gr = await userClient.LoginAsync(new UserRequest { Username = username.Text, Pw = CreateMD5(password.Password) });
                if (!gr.IsSuccessfull)
                {
                    MessageBox.Show("Couldn't login :(");
                    return;
                }
                myID = gr.Id;
                myUsername = username.Text;
                new OnlineUsersList().Show(); // open the list of current active players

                this.Close();

            }
        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            new Register().Show(); // open the list of current active players
        }

        private string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}

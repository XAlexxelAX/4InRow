using Grpc.Net.Client;
using grpc4InRowService.Protos;
using System;
using System.Text;
using System.Windows;

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
        private bool sentRequest;
        public LoginPage()
        {
            InitializeComponent();

            channel = GrpcChannel.ForAddress("https://localhost:5001");
            userClient = new User.UserClient(channel);
            sentRequest = false;
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
                try
                {
                    if (!sentRequest)
                    {
                        sentRequest = true;
                        GeneralReply gr = await userClient.LoginAsync(new UserRequest { Username = username.Text, Pw = CreateMD5(password.Password) });
                        if (!gr.IsSuccessfull)
                        {
                            sentRequest = false;
                            MessageBox.Show(gr.Error);
                            return;
                        }
                        myID = gr.Id;
                        myUsername = username.Text;
                        new OnlineUsersList().Show(); // open the list of current active players
                        sentRequest = false;
                        this.Close();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("An error occurred while trying to log in");
                }
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

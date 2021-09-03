using Grpc.Net.Client;
using grpc4InRowService.Protos;
using System;
using System.Text;
using System.Windows;

namespace connectFour
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private GrpcChannel channel;
        private User.UserClient userClient;
        private bool sentRequest;
        public Register()
        {
            InitializeComponent();
            try
            {
                channel = GrpcChannel.ForAddress("https://localhost:5001");
                userClient = new User.UserClient(channel);
            }
            catch (Grpc.Core.RpcException)
            {
                System.Windows.MessageBox.Show("An error from server has occurred", "Error");
            }
            sentRequest = false;

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
                try
                {
                    if (!sentRequest)
                    {
                        sentRequest = true;
                        var response = await userClient.RegisterAsync(new UserRequest { Username = username.Text, Pw = CreateMD5(password.Password) }); // register query

                        if (!response.IsSuccessfull) 
                        { // if query failed
                            MessageBox.Show(response.Error);
                            sentRequest = false;
                            return;
                        }
                        sentRequest = false;
                        this.Close();
                    }
                    sentRequest = true;
                }
                catch (Exception)
                { // if server is down
                    sentRequest = false;
                    MessageBox.Show("An error occurred while trying to log in");
                }
            }
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
                return sb.ToString(); // return the MD5 encryption as string
            }
        }
    }
}

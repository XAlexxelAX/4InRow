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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            if (username.Text.Equals("")) // check the input (username&password)
                MessageBox.Show("Username is empty!", "Input Error",
                                    MessageBoxButton.OK, MessageBoxImage.Question, MessageBoxResult.OK);
            else if (password.Password.Equals(""))
                MessageBox.Show("Password is empty!", "Input Error",
                                    MessageBoxButton.OK, MessageBoxImage.Question, MessageBoxResult.OK); 
            else
                new MainWindow().Show(); // open the list of current active players
        }
    }
}

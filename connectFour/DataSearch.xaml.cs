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
    /// Interaction logic for DataSearch.xaml
    /// </summary>
    public partial class DataSearch : Window
    {
        private List<string> usernames;
        public DataSearch()
        {
            InitializeComponent();
            usernames = new List<string>();
            //usernames.Add("Shahar Blank");
        }

        private void searchOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            users.Items.Clear();
            switch (searchOption.SelectedItem.ToString().Substring(38))
            {
                case "Users: Sorted by username":
                    foreach (string username in usernames)
                        users.Items.Add(username);
                    break;

                case "Users: Sorted by games amount":
                    break;

                case "Users: Sorted by wins amount":
                    break;

                case "Users: Sorted by loses amount":
                    break;

                case "Users: Sorted by points amount":
                    break;

                case "Games: Until now":
                    break;

                case "Games: Live":
                    break;

                case "Players: Data":
                    break;
            }
        }
    }
}

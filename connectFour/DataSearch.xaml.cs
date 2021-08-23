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
                    Grid DynamicGrid = new Grid();                 
                    DynamicGrid.ShowGridLines = true;
                    Grid.SetColumn(DynamicGrid, 1);
                    Grid.SetRow(DynamicGrid, 4);
                    mainGrid.Children.Add(DynamicGrid);

                    RowDefinition gridRow1 = new RowDefinition();
                    gridRow1.Height = new GridLength(50);
                    RowDefinition gridRow2 = new RowDefinition();
                    gridRow2.Height = new GridLength(50);
                    DynamicGrid.RowDefinitions.Add(gridRow1);
                    DynamicGrid.RowDefinitions.Add(gridRow2);

                    ColumnDefinition gridCol1 = new ColumnDefinition();
                    gridRow1.Height = new GridLength(50);
                    ColumnDefinition gridCol2 = new ColumnDefinition();
                    gridRow2.Height = new GridLength(50);
                    DynamicGrid.ColumnDefinitions.Add(gridCol1);
                    DynamicGrid.ColumnDefinitions.Add(gridCol2);

                    TextBlock txtBlock1 = new TextBlock();
                    txtBlock1.Text = "Test Title 1";
                    txtBlock1.FontSize = 14;
                    txtBlock1.FontWeight = FontWeights.Bold;
                    txtBlock1.Foreground = new SolidColorBrush(Colors.Green);
                    txtBlock1.VerticalAlignment = VerticalAlignment.Center;
                    txtBlock1.HorizontalAlignment = HorizontalAlignment.Center;
                    Grid.SetRow(txtBlock1, 0);
                    Grid.SetColumn(txtBlock1, 0);
                    DynamicGrid.Children.Add(txtBlock1);

                    TextBlock txtBlock2 = new TextBlock();
                    txtBlock2.Text = "Test Title 2";
                    txtBlock2.FontSize = 14;
                    txtBlock2.FontWeight = FontWeights.Bold;
                    txtBlock2.Foreground = new SolidColorBrush(Colors.Green);
                    txtBlock2.VerticalAlignment = VerticalAlignment.Top;
                    txtBlock2.VerticalAlignment = VerticalAlignment.Center;
                    txtBlock2.HorizontalAlignment = HorizontalAlignment.Center;
                    Grid.SetRow(txtBlock2, 0);
                    Grid.SetColumn(txtBlock2, 1);
                    DynamicGrid.Children.Add(txtBlock2);

                    break;

                case "Games: Live":
                    break;

                case "Players: Data":
                    break;
            }
        }
    }
}

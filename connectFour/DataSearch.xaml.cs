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
        private Grid DynamicGrid;
        public DataSearch()
        {
            InitializeComponent();
            usernames = new List<string>();

            DynamicGrid = new Grid();
            DynamicGrid.ShowGridLines = true;
            Grid.SetColumn(DynamicGrid, 1);
            Grid.SetRow(DynamicGrid, 4);
            mainGrid.Children.Add(DynamicGrid);
        }

        private void searchOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            users.Items.Clear();
            DynamicGrid.Children.Clear();
            DynamicGrid.Visibility = Visibility.Hidden;
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
                    int rows = 2, cols = 3;
                    DynamicGrid.Visibility = Visibility.Visible;
                    createRows(rows);
                    createCols(cols);
                    List<List<String>> rowsData = new List<List<String>>();
                    //TODO: Insert rows of data to list from DB
                    rowsData.Add(new List<string> { "Title1", "Title2", "Title3" });
                    rowsData.Add(new List<string> { "Data1", "Data2", "Data3" });

                    for (int i = 0; i < rows; insertDataToRow(i, rowsData[i], cols), i++) ;
                    break;

                case "Games: Live":
                    break;

                case "Players: Data":
                    break;
            }
        }

        private void insertDataToRow(int row, List<String> data, int cols)
        {
            for (int i = 0; i < cols; i++)
            {
                TextBlock txtBlock = new TextBlock();
                txtBlock.Text = data[i];
                txtBlock.FontSize = 14;
                txtBlock.FontWeight = FontWeights.Bold;
                txtBlock.Foreground = new SolidColorBrush(Colors.Green);
                txtBlock.VerticalAlignment = VerticalAlignment.Center;
                txtBlock.HorizontalAlignment = HorizontalAlignment.Center;
                Grid.SetRow(txtBlock, row);
                Grid.SetColumn(txtBlock, i);
                DynamicGrid.Children.Add(txtBlock);
            }
        }

        private void createCols(int cols)
        {
            for (int i = 0; i < cols; i++)
            {
                ColumnDefinition gridCol = new ColumnDefinition();
                gridCol.Width = new GridLength(dataCol.ActualWidth / cols);
                DynamicGrid.ColumnDefinitions.Add(gridCol);
            }
        }

        private void createRows(int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                RowDefinition gridRow = new RowDefinition();
                if (i == 0)
                    gridRow.Height = new GridLength(20);
                else
                    gridRow.Height = new GridLength((dataRow.ActualHeight - 30) / rows);

                DynamicGrid.RowDefinitions.Add(gridRow);
            }
        }
    }
}

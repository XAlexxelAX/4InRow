using Grpc.Core;
using Grpc.Net.Client;
using grpc4InRowService.Protos;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace connectFour
{
    /// <summary>
    /// Interaction logic for DataSearch.xaml
    /// </summary>
    public partial class DataSearch : Window
    {
        private List<(String, int, int, int, int, float, int)> usersList;
        private Grid DynamicGrid;
        private GrpcChannel channel;
        private Statistics.StatisticsClient statsClient;
        public static List<List<Object>> rowsData;
        public static List<(String, int)> pickedUsers;
        public DataSearch()
        {
            InitializeComponent();
            channel = GrpcChannel.ForAddress("https://localhost:5001");
            statsClient = new Statistics.StatisticsClient(channel);

            usersList = new List<(string, int, int, int, int, float, int)>();
            DynamicGrid = new Grid();

            DynamicGrid.ShowGridLines = true;
            Grid.SetColumn(DynamicGrid, 1);
            Grid.SetRow(DynamicGrid, 4);
            mainGrid.Children.Add(DynamicGrid);
        }

        private async void searchOption_SelectionChangedAsync(object sender, SelectionChangedEventArgs e)
        {
            users.Items.Clear();
            usersList.Clear();
            DynamicGrid.Children.Clear();
            DynamicGrid.RowDefinitions.Clear();
            DynamicGrid.ColumnDefinitions.Clear();
            DynamicGrid.Visibility = Visibility.Hidden;
            searchBtn.Visibility = Visibility.Hidden;
            users.HorizontalContentAlignment = HorizontalAlignment.Center;

            int rows, cols;

            using (var call = statsClient.getAllUsersStats(new StatsRequest()))
            {
                while (await call.ResponseStream.MoveNext())
                {
                    // (Username,Games,Wins,Loses,Score,Ratio,id)
                    usersList.Add((call.ResponseStream.Current.Username, call.ResponseStream.Current.Games, call.ResponseStream.Current.Wins,
                        call.ResponseStream.Current.Games - call.ResponseStream.Current.Wins, call.ResponseStream.Current.Score
                        , (float)call.ResponseStream.Current.Wins / call.ResponseStream.Current.Games * 100, call.ResponseStream.Current.Id));
                }
            }

            switch (searchOption.SelectedItem.ToString().Substring(38))
            {
                case "Users: Sorted by username":
                    usersList.Sort((x, y) => y.Item1.CompareTo(x.Item1));
                    usersList.Reverse(); // A->Z
                    foreach ((String, int, int, int, int, float, int) username in usersList)
                        users.Items.Add(username.Item1);
                    break;

                case "Users: Sorted by games amount":
                    usersList.Sort((x, y) => y.Item2.CompareTo(x.Item2));
                    foreach ((String, int, int, int, int, float, int) username in usersList)
                        users.Items.Add(username.Item1);
                    break;

                case "Users: Sorted by wins amount":
                    usersList.Sort((x, y) => y.Item3.CompareTo(x.Item3));
                    foreach ((String, int, int, int, int, float, int) username in usersList)
                        users.Items.Add(username.Item1);
                    break;

                case "Users: Sorted by loses amount":
                    usersList.Sort((x, y) => y.Item4.CompareTo(x.Item4));
                    foreach ((String, int, int, int, int, float, int) username in usersList)
                        users.Items.Add(username.Item1);
                    break;

                case "Users: Sorted by points amount":
                    usersList.Sort((x, y) => y.Item5.CompareTo(x.Item5));
                    foreach ((String, int, int, int, int, float, int) username in usersList)
                        users.Items.Add(username.Item1);
                    break;

                case "Games: Until now":
                    cols = 6;
                    DynamicGrid.Visibility = Visibility.Visible;
                    createCols(cols);

                    rowsData = new List<List<Object>>();
                    rowsData.Add(new List<Object> { "P1", "P2", "Winner", "P1 Points", "P2 Points", "Date" });
                    try
                    {
                        using (var call = statsClient.getFinisedGames(new StatsRequest()))
                        {
                            while (await call.ResponseStream.MoveNext())
                            {
                                string Date = String.Format("{2}/{3}/{4}\n{0}:{1}", call.ResponseStream.Current.Date.Hour, call.ResponseStream.Current.Date.Minute, call.ResponseStream.Current.Date.Day, call.ResponseStream.Current.Date.Month, call.ResponseStream.Current.Date.Year);
                                rowsData.Add(new List<Object>{call.ResponseStream.Current.User1, call.ResponseStream.Current.User2, call.ResponseStream.Current.Winner,
                                call.ResponseStream.Current.Score1,call.ResponseStream.Current.Score2,Date });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("An error occurred");
                    }
                    rows = rowsData.Count;
                    createRows(rows);

                    for (int i = 0; i < rows; insertDataToRow(i, rowsData[i], cols), i++) ;
                    break;

                case "Games: Live":
                    cols = 3;
                    DynamicGrid.Visibility = Visibility.Visible;
                    createCols(cols);

                    rowsData = new List<List<Object>>();
                    rowsData.Add(new List<Object> { "Date", "P1", "P2" });
                    using (var call = statsClient.getOngoingGames(new StatsRequest()))
                    {
                        while (await call.ResponseStream.MoveNext())
                        {
                            string Date = String.Format("{2}/{3}/{4}\n{0}:{1}", call.ResponseStream.Current.Date.Hour, call.ResponseStream.Current.Date.Minute, call.ResponseStream.Current.Date.Day, call.ResponseStream.Current.Date.Month, call.ResponseStream.Current.Date.Year);
                            rowsData.Add(new List<Object> { Date, call.ResponseStream.Current.User1, call.ResponseStream.Current.User2 });
                        }
                    }
                    rows = rowsData.Count;
                    createRows(rows);
                    for (int i = 0; i < rows; insertDataToRow(i, rowsData[i], cols), i++) ;
                    break;

                case "Players: Data":
                    searchBtn.Visibility = Visibility.Visible;
                    users.HorizontalContentAlignment = HorizontalAlignment.Left;
                    foreach ((String, int, int, int, int, float, int) username in usersList)
                    {
                        ListBoxItem newUser = new ListBoxItem();
                        newUser.Content = new CheckBox();
                        TextBlock txt = new TextBlock();
                        txt.Text = username.Item1;
                        ((CheckBox)newUser.Content).Content = txt;
                        ((CheckBox)newUser.Content).DataContext = username.Item7;
                        ((TextBlock)((CheckBox)newUser.Content).Content).Margin = new Thickness(160, 0, 0, 0);

                        users.Items.Add(newUser);
                    }
                    break;
            }
        }

        private async void DataSearch_ClickedAsync(object sender, RoutedEventArgs e)
        {
            int amount = playersPicked_amount();
            if (amount == 0 || amount > 2)
                MessageBox.Show("You can only pick 1 or 2 players!", "Error!");
            else if (amount == 1)
            {
                rowsData = new List<List<Object>>();
                rowsData.Add(new List<Object> { "Games", "Wins", "Wins Ratio", "Points" });

                var call = statsClient.getUserStats(new StatsRequest { Id1 = getCheckedUsers()[0].Item2 });

                rowsData.Add(new List<Object> { call.Games, call.Wins, "" + (float)call.Wins / call.Games * 100 + "%", call.Score });

                new PlayersData().Show();
            }
            else // amount==2
            {
                rowsData = new List<List<Object>>();
                rowsData.Add(new List<Object> { "Game Date", "Winner", "P1 Points", "P2 Points" });
                using (var call = statsClient.getUsersIntersection(new StatsRequest { Id1 = getCheckedUsers()[0].Item2, Id2 = getCheckedUsers()[1].Item2 }))
                {
                    while (await call.ResponseStream.MoveNext())
                    {
                        string Date = String.Format("{2}/{3}/{4}\n{0}:{1}", call.ResponseStream.Current.Date.Hour, call.ResponseStream.Current.Date.Minute, call.ResponseStream.Current.Date.Day, call.ResponseStream.Current.Date.Month, call.ResponseStream.Current.Date.Year);
                        rowsData.Add(new List<Object> { Date, call.ResponseStream.Current.Winner
                            ,call.ResponseStream.Current.Score1, call.ResponseStream.Current.Score2 });
                    }
                }
                new PlayersData().Show();
            }
        }

        private int playersPicked_amount()
        {
            int count = 0;
            foreach (ListBoxItem checkBox in users.Items)
                if (((CheckBox)checkBox.Content).IsChecked == true)
                    count++;
            return count;
        }

        private void insertDataToRow(int row, List<Object> data, int cols)
        {
            for (int i = 0; i < cols; i++)
            {
                TextBlock txtBlock = new TextBlock();
                txtBlock.Text = data[i].ToString();
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

        private List<(String, int)> getCheckedUsers()
        {
            // initate or clear list
            if (pickedUsers == null)
                pickedUsers = new List<(String, int)>();
            else
                pickedUsers.Clear();

            foreach (ListBoxItem listBoxItem in users.Items) // make list of pairs of (username,id) that are picked
                if (((CheckBox)listBoxItem.Content).IsChecked == true)
                    pickedUsers.Add((((TextBlock)((CheckBox)listBoxItem.Content).Content).Text, (int)((CheckBox)listBoxItem.Content).DataContext));
            return pickedUsers;
        }
    }
}

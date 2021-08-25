using Grpc.Core;
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
    /// Interaction logic for DataSearch.xaml
    /// </summary>
    public partial class DataSearch : Window
    {
        private List<(String, int, int, int, int, float)> usersList;
        private Grid DynamicGrid;
        private GrpcChannel channel;
        private Statistics.StatisticsClient statsClient;
        public DataSearch()
        {
            InitializeComponent();
            channel = GrpcChannel.ForAddress("https://localhost:5001");
            statsClient = new Statistics.StatisticsClient(channel);
            usersList = new List<(string, int, int, int, int, float)>();
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

            int rows, cols;
            List<List<Object>> rowsData;

            using (var call = statsClient.getAllUsersStats(new StatsRequest()))
            {
                while (await call.ResponseStream.MoveNext())
                {
                    // (Username,Games,Wins,Loses,Score,Ratio)
                    usersList.Add((call.ResponseStream.Current.Username, call.ResponseStream.Current.Games, call.ResponseStream.Current.Wins,
                        call.ResponseStream.Current.Games - call.ResponseStream.Current.Wins, call.ResponseStream.Current.Score
                        , (float)call.ResponseStream.Current.Wins / call.ResponseStream.Current.Games));
                }
            }

            switch (searchOption.SelectedItem.ToString().Substring(38))
            {
                case "Users: Sorted by username":
                    usersList.Sort((x, y) => y.Item1.CompareTo(x.Item1));
                    usersList.Reverse(); // A->Z
                    foreach ((String, int, int, int, int, float) username in usersList)
                        users.Items.Add(username.Item1);
                    break;

                case "Users: Sorted by games amount":
                    usersList.Sort((x, y) => y.Item2.CompareTo(x.Item2));
                    foreach ((String, int, int, int, int, float) username in usersList)
                        users.Items.Add(username.Item1);
                    break;

                case "Users: Sorted by wins amount":
                    usersList.Sort((x, y) => y.Item3.CompareTo(x.Item3));
                    foreach ((String, int, int, int, int, float) username in usersList)
                        users.Items.Add(username.Item1);
                    break;

                case "Users: Sorted by loses amount":
                    usersList.Sort((x, y) => y.Item4.CompareTo(x.Item4));
                    foreach ((String, int, int, int, int, float) username in usersList)
                        users.Items.Add(username.Item1);
                    break;

                case "Users: Sorted by points amount":
                    usersList.Sort((x, y) => y.Item5.CompareTo(x.Item5));
                    foreach ((String, int, int, int, int, float) username in usersList)
                        users.Items.Add(username.Item1);
                    break;

                case "Games: Until now":
                    cols = 6;
                    DynamicGrid.Visibility = Visibility.Visible;
                    createCols(cols);

                    rowsData = new List<List<Object>>();
                    rowsData.Add(new List<Object> { "P1", "P2", "Winner", "P1 Points", "P2 Points", "Date" });
                    using (var call = statsClient.getFinisedGames(new StatsRequest()))
                    {
                        while (await call.ResponseStream.MoveNext())
                        {
                            rowsData.Add(new List<Object>{call.ResponseStream.Current.User1, call.ResponseStream.Current.User2, call.ResponseStream.Current.Winner,
                                call.ResponseStream.Current.Score1,call.ResponseStream.Current.Score2,call.ResponseStream.Current.Date });
                        }
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
                    rowsData.Add(new List<Object> { "P1", "P2", "Date" });
                    using (var call = statsClient.getOngoingGames(new StatsRequest()))
                    {
                        while (await call.ResponseStream.MoveNext())
                        {
                            rowsData.Add(new List<Object> { call.ResponseStream.Current.User1, call.ResponseStream.Current.User2, call.ResponseStream.Current.Date });
                        }
                    }
                    rows = rowsData.Count;
                    createRows(rows);
                    for (int i = 0; i < rows; insertDataToRow(i, rowsData[i], cols), i++) ;
                    break;

                case "Players: Data":
                    int amount = playersPicked_amount();
                    if (amount == 0 || amount > 2)
                    {
                        MessageBox.Show("You can only pick 1 or 2 players!");
                        return;
                    }
                    else if (amount == 1)
                    {
                        cols = 4;
                        DynamicGrid.Visibility = Visibility.Visible;
                        createCols(cols);

                        rowsData = new List<List<Object>>();
                        rowsData.Add(new List<Object> { "Games", "Wins", "Wins Precentage", "Points" });
                        var call = statsClient.getUserStats(new StatsRequest());

                        rowsData.Add(new List<Object> { call.Games, call.Wins, ""+((float)call.Wins / call.Games)+"%", call.Score });

                        rows = rowsData.Count;
                        createRows(rows);
                        for (int i = 0; i < rows; insertDataToRow(i, rowsData[i], cols), i++) ;
                    }
                    else // amount==2
                    {
                        cols = 4;
                        DynamicGrid.Visibility = Visibility.Visible;
                        createCols(cols);

                        rowsData = new List<List<Object>>();
                        rowsData.Add(new List<Object> { "Games", "Wins", "Wins Precentage", "Points" });
                        //TODO: Insert rows of data to list from DB

                        rows = rowsData.Count;
                        createRows(rows);
                        for (int i = 0; i < rows; insertDataToRow(i, rowsData[i], cols), i++) ;
                    }
                    Grid.SetRow(DynamicGrid, 5);


                    break;
            }
        }

        private int playersPicked_amount()
        {
            throw new NotImplementedException();
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
    }
}

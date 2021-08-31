using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace connectFour
{
    /// <summary>
    /// Interaction logic for PlayersData.xaml
    /// </summary>
    public partial class PlayersData : Window
    {
        private Grid DynamicGrid;
        private int rows, cols;
        public PlayersData()
        {
            InitializeComponent();
            showData();
        }

        private void showData()
        {
            DynamicGrid = new Grid();

            DynamicGrid.ShowGridLines = true;
            Grid.SetColumn(DynamicGrid, 1);
            Grid.SetRow(DynamicGrid, 2);
            mainGrid.Children.Add(DynamicGrid);

            cols = DataSearch.rowsData[0].Count;
            rows = DataSearch.rowsData.Count;

            createCols();
            createRows();
            for (int i = 0; i < rows; insertDataToRow(i, DataSearch.rowsData[i], cols), i++) ;

            int p1Wins = 0;

            if (DataSearch.rowsData.Count > 1 && DataSearch.rowsData[0][0].Equals("Game Date")) // 2 players were picked
            {
                winRatioTxt.Visibility = Visibility.Visible;

                foreach (List<Object> rowData in DataSearch.rowsData)
                    if (rowData[1].Equals(DataSearch.rowsData[1][1]))
                        p1Wins++;

                if (DataSearch.rowsData[1][1].Equals(DataSearch.pickedUsers[0].Item1))
                    winRatioTxt.Text = "Win Ratio:\n" + DataSearch.pickedUsers[0].Item1 + ": " + (float)p1Wins / (DataSearch.rowsData.Count - 1) * 100 + "%" +
                            " <> " + DataSearch.pickedUsers[1].Item1 + ": " + (1 - (float)p1Wins / (DataSearch.rowsData.Count - 1)) * 100 + "%";
                else winRatioTxt.Text = "Win Ratio:\n" + DataSearch.pickedUsers[1].Item1 + ": " + (float)p1Wins / (DataSearch.rowsData.Count - 1) * 100 + "%" +
                           " <> " + DataSearch.pickedUsers[0].Item1 + ": " + (1 - (float)p1Wins / (DataSearch.rowsData.Count - 1)) * 100 + "%";
            }
            else if (DataSearch.rowsData[0][0].Equals("Game Date"))// 2 players were picked
            {
                winRatioTxt.Visibility = Visibility.Visible;
                winRatioTxt.Text = "These 2 players haven't played each other yet.";
            }
        }

        private void createCols()
        {
            for (int i = 0; i < cols; i++)
            {
                ColumnDefinition gridCol = new ColumnDefinition();
                gridCol.Width = new GridLength(330 / cols);
                DynamicGrid.ColumnDefinitions.Add(gridCol);
            }
        }

        private void createRows()
        {
            for (int i = 0; i < rows; i++)
            {
                RowDefinition gridRow = new RowDefinition();
                if (i == 0)
                    gridRow.Height = new GridLength(20);
                else
                    gridRow.Height = new GridLength((250 - 30) / rows);

                DynamicGrid.RowDefinitions.Add(gridRow);
            }
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
    }
}

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
        }

        private void createCols()
        {
            for (int i = 0; i < cols; i++)
            {
                ColumnDefinition gridCol = new ColumnDefinition();
                gridCol.Width = new GridLength(dataCol.ActualWidth / cols);
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
                    gridRow.Height = new GridLength((dataRow.ActualHeight - 30) / rows);

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

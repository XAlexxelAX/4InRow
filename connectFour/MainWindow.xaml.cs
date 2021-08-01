using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace connectFour
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int[,] board;
        private int turn;
        public MainWindow()
        {
            InitializeComponent();
            initVars();
        }

        private void initVars()
        {
            board = new int[7, 6];
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); board[i, j++] = 0) ; // init empty board

            turn = 0;
        }

        private void OnPreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            /*if (e.ClickCount == 2) // for double-click, remove this condition if only want single click
            {*/
            var point = Mouse.GetPosition(boardView);

            int row = 0, col = 0;
            double accumulatedHeight = 0, accumulatedWidth = 0;

            // calc row mouse was over
            foreach (var rowDefinition in boardView.RowDefinitions)
            {
                accumulatedHeight += rowDefinition.ActualHeight;
                if (accumulatedHeight >= point.Y)
                    break;
                row++;
            }

            // calc col mouse was over
            foreach (var columnDefinition in boardView.ColumnDefinitions)
            {
                accumulatedWidth += columnDefinition.ActualWidth;
                if (accumulatedWidth >= point.X)
                    break;
                col++;
            }

            updateBoard(row - 1, col - 2);
            turn = 1 - turn;
            // row and col now correspond Grid's RowDefinition and ColumnDefinition mouse was 
            // over when double clicked!
            //}
        }

        private void updateBoard(int row, int col)
        {
            int emptyCell_row = findEmptyColCell(col);
            if (emptyCell_row == -1)
                return;

            var img = new Image { Width = 70, Height = 70 };
            BitmapImage bitmapImage;
            String path = Environment.CurrentDirectory.Split("connectFour")[0] + "connectFour\\Resources\\";

            if (turn == 0)
                bitmapImage = new BitmapImage(new Uri(path + "pred.png"));
            else
                bitmapImage = new BitmapImage(new Uri(path + "pyellow.png"));

            img.Source = bitmapImage;

            img.SetValue(Grid.RowProperty, emptyCell_row + 1);
            img.SetValue(Grid.ColumnProperty, col + 2);

            boardView.Children.Add(img);

            board[emptyCell_row, col] = turn + 1;
        }

        private int findEmptyColCell(int j)
        {
            for (int i = board.GetLength(0) - 1; i >= 0; i--)
                if (board[i, j] == 0)
                    return i;
            return -1; // return -1 if all col is full
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for MyMsgBox.xaml
    /// </summary>
    public partial class MyMsgBox : Window
    {
        public MyMsgBox(String msg)
        {
            InitializeComponent();
            myMsgBox.Text = msg;
        }
    }
}

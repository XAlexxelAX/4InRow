using System;
using System.Windows;

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

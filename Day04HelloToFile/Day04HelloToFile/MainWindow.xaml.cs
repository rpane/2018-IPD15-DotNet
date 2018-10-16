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

namespace Day04HelloToFile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnHello_Click(object sender, RoutedEventArgs e)
        {
            if (tbName.Text.Length < 2 || tbName.Text.Length > 30)
            {
                throw new Exception("Name is too short");
            }
            if (tbName.Text.Contains(";"))
            {
                throw new Exception("Cannot have a semicolon");
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tbName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbName.Text.Length < 2 || tbName.Text.Length > 30)
            {
                MessageBox.Show("Name is too short");
            }
            if (tbName.Text.Contains(";"))
            {
                MessageBox.Show("Cannot have a semicolon");
            }
        }

        /*
         * if (tbName.Text.Length <2 || tbName.Text.Length >30)
            {
                MessageBox.Show("Name is too short");
            }
         */


    }
}

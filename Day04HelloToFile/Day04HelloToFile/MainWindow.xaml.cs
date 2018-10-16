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
            if (int.Parse(tbAge.Text) < 1 | int.Parse(tbAge.Text) > 150)
            {
                throw new Exception("Age needs to be between 1-150");
            }

            MessageBox.Show(string.Format("Hello {0}, you are {1} y/o.",tbName.Text,tbAge.Text));
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (tbName.Text == "" | tbAge.Text =="")
            {
                throw new Exception("Fill required fields");
            }
            string text = string.Format("{0};{1}", tbName.Text, tbAge.Text);
            System.IO.File.AppendAllText(@"..\..\people.txt", text +Environment.NewLine);

            tbName.Text = "";
            tbAge.Text = "";

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

        private void tbAge_LostFocus(object sender, RoutedEventArgs e)
        {
            if (int.Parse(tbAge.Text) < 1 | int.Parse(tbAge.Text) > 150)
            {
                MessageBox.Show("Age needs to be between 1-150");
            }
        }
    }
}

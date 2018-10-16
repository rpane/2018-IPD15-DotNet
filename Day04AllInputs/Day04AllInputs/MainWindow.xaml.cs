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

namespace Day04AllInputs
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

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {

            if (tbName.Text == "")
            {
                MessageBox.Show("Please Enter your name");
                throw new Exception("Please Enter your name");
            }
            string name = tbName.Text;
            string text = string.Format("{0};{1};{2};{3};{4: 0.00}°C", name,btnChoice(),petChoice(),cbContinents.Text,tbSliderVal.Text);
            System.IO.File.AppendAllText(@"..\..\friends.txt", text + Environment.NewLine);

            tbName.Text = "";
            slTemp.Value = 25;
            rb18_35.IsChecked = false;
            rb36_.IsChecked = false;
            rbBelow18.IsChecked = false;
            cbCat.IsChecked = false;
            cbDog.IsChecked = false;
            cbOther.IsChecked = false;
            cbContinents.SelectedIndex = 0;

        }
        public String btnChoice()
        {
            String Age;

         if (rbBelow18.IsChecked == true)
            {
                Age = "Below 18";
            }else if(rb18_35.IsChecked == true)
            {
                Age = "18-35";
            }else if(rb36_.IsChecked == true)
            {
                Age = "36 and up";
            }
            else
            {
                Age = "";
            }

        return Age;
    }

        public String petChoice()
        {
            String res = "";
            if (cbCat.IsChecked == true && cbDog.IsChecked == true && cbOther.IsChecked == true)
            {
                res = "Cat,Dog,Other";
            }
            else if (cbCat.IsChecked == true && cbDog.IsChecked == true)
            {
                res = "Cat,Dog";
            }
            else if (cbCat.IsChecked == true && cbOther.IsChecked == true)
            {
                res = "Cat,Other";
            }
            else if (cbDog.IsChecked == true && cbOther.IsChecked == true)
            {
                res = "Dog,Other";
            }
            else if (cbDog.IsChecked == true)
            {
                res = "Dog";
            }
            else if (cbCat.IsChecked == true)
            {
                res = "Cat";
            }
            else if (cbOther.IsChecked == true)
            {
                res = "Other";
            }
            else
            {
                res = "No Pet";
            }
            return res;
        }
    }
}

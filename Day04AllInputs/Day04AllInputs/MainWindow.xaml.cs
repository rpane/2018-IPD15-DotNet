using System;
using System.Collections.Generic;
using System.IO;
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
            rbBelow18.IsChecked = true;

            
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            //Instead of a String method create a list of petChoices
            List<string> petList = new List<string>();
            if (cbCat.IsChecked == true) petList.Add("Cat");
            if (cbDog.IsChecked == true) petList.Add("Dog");
            if (cbOther.IsChecked == true) petList.Add("Other");
            string petStr = string.Join(",", petList);

            if (tbName.Text == "")
            {
                MessageBox.Show("Please Enter your name");
                throw new Exception("Please Enter your name");
            }
            string name = tbName.Text;
            string text = string.Format("{0};{1};{2};{3};{4: 0.00}°C", name,btnChoice(),petStr,cbContinents.Text, lblSliderVal.Content.ToString());
            try
            {
                System.IO.File.AppendAllText(@"..\..\friends.txt", text + Environment.NewLine);
            }catch(IOException E)
            {
                MessageBox.Show(this, "Failed to write data to file.\n" + E.Message, "File Error");
            }

            tbName.Text = "";
            slTemp.Value = 25;
            rb18_35.IsChecked = false;
            rb36_.IsChecked = false;
            rbBelow18.IsChecked = true;
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
       
         
        //Used List in btn Event instead of this method
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
        string selectedAge = "";
        private void rbBelow18_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            selectedAge = rb.Content.ToString();
        }
    }
}

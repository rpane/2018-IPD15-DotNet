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

namespace Day04TempConverter
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

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            string input = tbInput.Text;
            double output;

            

            if (rbInputCel.IsChecked == true)
            {
                if(rbOutputCel.IsChecked == true)
                {
                    tbOutput.Text = string.Format("{0: 0.00}°C",input);
                }
                else if (rbOutputFah.IsChecked == true)
                {
                    output = (double.Parse(input) * 9 / 5) + 32; 
                    tbOutput.Text = string.Format("{0: 0.00}°F", output);
                }
                else if (rbOutputKel.IsChecked == true)
                {
                    output = double.Parse(input) + 273.15;
                    tbOutput.Text = string.Format("{0: 0.00}°K", output);
                }
            }
            else if (rbInputFah.IsChecked == true)
            {
                if (rbOutputCel.IsChecked == true)
                {
                    output = (double.Parse(input) - 32) * 5 / 9;
                    tbOutput.Text = string.Format("{0: 0.00}°C", output);
                }
                else if (rbOutputFah.IsChecked == true)
                {                    
                    tbOutput.Text = string.Format("{0: 0.00}°F", input);
                }
                else if (rbOutputKel.IsChecked == true)
                {
                    output = (double.Parse(input) -32)*5/9 + 273.15;
                    tbOutput.Text = string.Format("{0: 0.00}°K", output);
                }
            }
            else if (rbInputKel.IsChecked == true)
            {
                if (rbOutputCel.IsChecked == true)
                {
                    output = double.Parse(input) - 273.15;
                    tbOutput.Text = string.Format("{0: 0.00}°C", output);
                }
                else if (rbOutputFah.IsChecked == true)
                {
                    output = (double.Parse(input) - 273.15) * 9 / 5 + 32;
                    tbOutput.Text = string.Format("{0: 0.00}°F", output);
                }
                else if (rbOutputKel.IsChecked == true)
                {                    
                    tbOutput.Text = string.Format("{0: 0.00}°K", input);
                }
            }
        }
    }
}

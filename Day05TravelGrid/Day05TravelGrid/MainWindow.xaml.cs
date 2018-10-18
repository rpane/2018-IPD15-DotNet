using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Day05TravelGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Trip> trips = new List<Trip>();
        public MainWindow()
        {
            InitializeComponent();
            lvTravel.ItemsSource = trips;
          
        }

        private void btnAddTrip_Click(object sender, RoutedEventArgs e)
        {            
            String destination = tbDestination.Text;
            String name = tbName.Text;
            String passport = tbPassportNo.Text;
            DateTime depart = DateTime.Parse(tbDeparture.Text);
            DateTime returnDate = DateTime.Parse(tbReturn.Text);
            Trip a = new Trip(destination, name, passport, depart, returnDate);
            trips.Add(a);
            lvTravel.Items.Refresh();          
            
        }

        private void tbDestination_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbDestination.Text.Length < 2 || tbDestination.Text.Length > 30)
            {
                MessageBox.Show("Destination needs to be\nbetween 2 and 30 characters");
            }
        }

        private void tbName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbName.Text.Length < 2 || tbName.Text.Length > 30)
            {
                MessageBox.Show("Name needs to be\nbetween 2 and 30 characters");
            }
        }

        private void tbPassportNo_LostFocus(object sender, RoutedEventArgs e)
        {
            String passport = tbPassportNo.Text;
            string pattern = @"[A-Z]{2}\d{6}";
            Match m = Regex.Match(passport, pattern);
            if (!m.Success)
            {
                MessageBox.Show("Passport format is \"AA123456");
            }
        }

        private void tbDeparture_LostFocus(object sender, RoutedEventArgs e)
        {

            String depart = tbDeparture.Text;
            string pattern = @"\d{2}\/\d{2}\/\d{4}";
            Match m = Regex.Match(depart, pattern);
            if (!m.Success)
            {
                MessageBox.Show("Date format is MM/DD/YYYY");
            }
        }

        private void tbReturn_LostFocus(object sender, RoutedEventArgs e)
        {
            String returnDate = tbReturn.Text;
            string pattern = @"\d{2}\/\d{2}\/\d{4}";
            Match m = Regex.Match(returnDate, pattern);
            if (!m.Success)
            {
                MessageBox.Show("Date format is MM/DD/YYYY");
            }
        }

        private void btnSaveSel_Click(object sender, RoutedEventArgs e)
        {
            string filename = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Trip File (.trips) | *.trips";
            sfd.Title = "Save a Trip File";
            sfd.DefaultExt = ".trips";
            if (sfd.ShowDialog() == true)
            {
                filename = sfd.FileName.ToString();
                if (filename != "")
                {
                    using (StreamWriter sw = new StreamWriter(filename))
                    {
                        foreach (var item in lvTravel.SelectedItems)
                        {
                            sw.WriteLine(item.ToString());
                        }
                    }
                }
            }
        }
    }
}

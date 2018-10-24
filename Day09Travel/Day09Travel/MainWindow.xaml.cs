using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Day09Travel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                Globals.db = new Database();
                RefreshList();                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(this, "Error connecting to database:\n" + ex.Message, "Database error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(1);
            }
        }

        private void btnSaveSel_Click(object sender, RoutedEventArgs e)
        {
            string filename = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Trips File (.trips) | *.trips";
            sfd.Title = "Save a Trips File";
            sfd.DefaultExt = ".trips";
            if (sfd.ShowDialog() == true)
            {
                filename = sfd.FileName.ToString();
                if (filename != "")
                {
                    using (StreamWriter sw = new StreamWriter(filename))
                    {
                        foreach (var item in lvTrips.SelectedItems)
                        {
                            sw.WriteLine(item.ToString());
                        }
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditDialog dlg = new AddEditDialog(this);
            if (dlg.ShowDialog() == true)
            {
                RefreshList();
                MessageBox.Show("Success!");
            }
        }
        void RefreshList()
        {
            try
            {
                List<Trip> list = Globals.db.GetAllTrips();
                lvTrips.ItemsSource = list;
                // no need to do Refresh if we assign to ItemsSource
            }
            catch (SqlException ex)
            {
                MessageBox.Show(this, ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

      
        private void gvIDHeader_Click(object sender, RoutedEventArgs e)
        {
            List<Trip> list = Globals.db.GetAllTrips();
            List<Trip> sorted = list.OrderBy(Trip => Trip.Id).ToList();
            lvTrips.ItemsSource = sorted;
        }

        private void gvDestinationHeader_Click(object sender, RoutedEventArgs e)
        {
            List<Trip> list = Globals.db.GetAllTrips();
            List<Trip> sorted = list.OrderBy(Trip => Trip.Destination).ToList();
            lvTrips.ItemsSource = sorted;
        }

        private void gvNameHeader_Click(object sender, RoutedEventArgs e)
        {
            List<Trip> list = Globals.db.GetAllTrips();
            List<Trip> sorted = list.OrderBy(Trip => Trip.Name).ToList();
            lvTrips.ItemsSource = sorted;
        }

        private void lvTrips_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Trip currTrip = lvTrips.SelectedItem as Trip;
            if (currTrip == null) return;

            AddEditDialog dlg = new AddEditDialog(this, currTrip);
            if (dlg.ShowDialog() == true)
            {
                RefreshList();
                MessageBox.Show("Success!");
            }
        }
    }
}

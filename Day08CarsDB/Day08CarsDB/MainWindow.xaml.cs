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

namespace Day08CarsDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Cars> allCars = new List<Cars>();
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                Globals.db = new Database();
                allCars = Globals.db.GetAllCars();
                refreshList();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(this, "Error connecting to database:\n" + ex.Message, "Database error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(1);
            }
        }
       

        private void miAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditDialog dlg = new AddEditDialog(this);
            if (dlg.ShowDialog() == true)
            {
                refreshList();
                MessageBox.Show("Success!");
            }
        }

        private void lbPeople_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Cars currCar = lbCars.SelectedItem as Cars;
            if (currCar == null) return;

            AddEditDialog dlg = new AddEditDialog(this, currCar);
            if (dlg.ShowDialog() == true)
            {
                refreshList();
                MessageBox.Show("Success!");
            }
        }

        private void miDelete_Click(object sender, RoutedEventArgs e)
        {
            Cars currCar = lbCars.SelectedItem as Cars;
            if (currCar == null) return;
            //
            MessageBoxResult result = MessageBox.Show(this, "Are you sure you want to delete:\n" +
                currCar, "Confirm delete", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            //
            if (result == MessageBoxResult.OK)
            {
                try
                {
                    Globals.db.DeleteCar(currCar.Id);
                    refreshList();


                }
                catch (SqlException ex)
                {
                    MessageBox.Show(this, ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

       
       void refreshList()
        {
            lbCars.Items.Clear();
            allCars = Globals.db.GetAllCars();
            foreach(var val in allCars)
            {
                lbCars.Items.Add(val);
            }
        }

        private void miEdit_Click(object sender, RoutedEventArgs e)
        {
            Cars currCar = lbCars.SelectedItem as Cars;
            if (currCar == null) return;

            AddEditDialog dlg = new AddEditDialog(this, currCar);
            if (dlg.ShowDialog() == true)
            {
                refreshList();
                MessageBox.Show("Success!");
            }
        }

        private void miExit_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit without saving", "Exit confirmation",
               MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
            else if (result == MessageBoxResult.No)
            {
                miExport_Click(sender, e);
            }
        }

        private void miExport_Click(object sender, RoutedEventArgs e)
        {
            string filename = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV File (.csv) | *.csv";
            sfd.Title = "Save a Csv File";
            sfd.DefaultExt = ".csv";
            if (sfd.ShowDialog() == true)
            {
                filename = sfd.FileName.ToString();
                if (filename != "")
                {
                    using (StreamWriter sw = new StreamWriter(filename))
                    {
                        foreach (var item in lbCars.Items)
                        {
                            sw.WriteLine(item.ToString());
                        }
                    }
                }
            }
        }
    }
}

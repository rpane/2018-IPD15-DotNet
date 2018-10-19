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

namespace Quiz02Airports
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Airport> airpotList = new List<Airport>();
        bool isSaved = false;
        public MainWindow()
        {
            InitializeComponent();
            lvAirport.ItemsSource = airpotList;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if(lvAirport.SelectedIndex == -1)
            {
                MessageBox.Show(this, "Unable to update, nothing selected", "Input error");
                return;
            }

            string Code = tbCode.Text;
            string City = tbCity.Text;
            double lat = 0;
            if(!double.TryParse(tbLat.Text, out lat)){
                MessageBox.Show(this, "Lat must be numerical", "Input error");
                return;
            }
            double log = 0;
            if(!double.TryParse(tbLog.Text, out log))
            {
                MessageBox.Show(this, "Log must be numerical", "Input error");
                return;
            }
            int ele = (int)(slidElevation.Value);
            try
            {
                Airport z = lvAirport.SelectedItem as Airport;
                Airport.checkCityValid(City);
                Airport.checkCodeValid(Code);
                z.Code = Code;
                z.City = City;
                z.Lat = lat;
                z.Log = log;
                z.Elevation = ele;
                lvAirport.Items.Refresh();
                resetFields();
            }catch(ArgumentException ex)
            {
                MessageBox.Show(this, ex.Message, "Input error");
                return;
            }
            
        }

        public void resetFields()
        {
            tbCode.Text = "";
            tbCity.Text = "";
            tbLat.Text = "";
            tbLog.Text = "";
            slidElevation.Value = 900;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (tbCity.Text =="")// Need to add additional checks
            {
                MessageBox.Show(this, "Unable to Add, nothing is Entered", "Input error");
                return;
            }
            string Code = tbCode.Text;
            string City = tbCity.Text;
            double lat = double.Parse(tbLat.Text);
            double log = double.Parse(tbLog.Text);
            int ele = (int)(slidElevation.Value);
            Airport a = new Airport(Code, City, lat, log, ele);
            airpotList.Add(a);
            lvAirport.Items.Refresh();
            resetFields();
        }

        private void btnBetween_Click(object sender, RoutedEventArgs e)
        {
            if (lvAirport.SelectedItems.Count < 2)
            {                
                MessageBox.Show(this, "Not enough airports to determine distance between", "Input error");
                return;
            }
            double distance;
            List<Airport> distances = new List<Airport>();
            foreach(var val in lvAirport.SelectedItems)
            {
                Airport x = val as Airport;
                distances.Add(x);
            }
            double cordx1 = 0, cordx2 = 0, cordy1 = 0, cordy2 = 0;
            cordx1 = distances[0].Log;
            cordx2 = distances[1].Log;
            cordy1 = distances[0].Lat;
            cordy2 = distances[1].Lat;
            distance = Math.Sqrt((cordx2 - cordx1) * (cordx2 - cordx1) + (cordy2 - cordy1) * (cordy2 - cordy1));
            MessageBox.Show(string.Format("The Distances between the selected Aiports is\n{0: 0.00}", distance));
        }

        private void btnNearest_Click(object sender, RoutedEventArgs e)
        {
            if(lvAirport.Items.Count <= 2)
            {                
                MessageBox.Show(this, "Not enough airports to find nearest", "Input error");
                return;
            }
            int indexFound = lvAirport.SelectedIndex;
            List<Airport> allAirports = new List<Airport>();
            int i = 0;
            Airport a = lvAirport.SelectedItem as Airport;
            double[] nearestDist = new double[lvAirport.Items.Count];
            foreach(var val in lvAirport.Items)
            {
                double cordx1, cordx2, cordy1, cordy2, distance;
                Airport b = val as Airport;
                if(b.Lat == a.Lat && b.Log == a.Log)
                {
                    continue;
                }
                allAirports.Add(b);
                cordy1 = b.Lat;
                cordx1 = b.Log;

                ;
                cordy2 = a.Lat;
                cordx2 = a.Log;
                distance = Math.Sqrt((cordx2 - cordx1) * (cordx2 - cordx1) + (cordy2 - cordy1) * (cordy2 - cordy1));

                nearestDist[i] = distance;
                i++;
            }
            
            double minVal = nearestDist[0];
            int foundIndex = 0;
            for (int k = 1; k < nearestDist.Length; k++)
            {
                if (nearestDist[k] == 0)
                {
                    continue;
                }
                if (nearestDist[k] < minVal)
                {
                    minVal = nearestDist[k];
                    foundIndex = k;
                }
            }

            MessageBox.Show("Closest Airport is "+allAirports[foundIndex].City+ " which is "+ minVal + "distance away");

        }

        private void lvAirport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Airport x = lvAirport.SelectedItem as Airport;
            if (x == null) return;
            lblID.Content = x.Id;
            tbCode.Text = x.Code;
            tbCity.Text = x.City;
            tbLat.Text = x.Lat.ToString();
            tbLog.Text = x.Log.ToString();
            slidElevation.Value = x.Elevation;
        }

        private void miOpen_Click(object sender, RoutedEventArgs e)
        {
            airpotList.Clear();
            lvAirport.Items.Refresh();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open CSV File";
            ofd.Filter = " CSV files |*.csv";
            if (ofd.ShowDialog() == true)
            {
                string filename = ofd.FileName;
                string[] lines = File.ReadAllLines(filename);
                foreach (string line in lines)
                {
                    string[] words = line.Split(',');
                    long id = long.Parse(words[0]);
                    string code = words[1];
                    string city = words[2];
                    double lat = double.Parse(words[3]);
                    double log = double.Parse(words[4]);
                    int ele = int.Parse(words[5]);
                    Airport.checkCityValid(city);
                    Airport.checkCodeValid(code);
                    Airport x = new Airport(code, city, lat, log, ele);
                    x.Id = id;
                    airpotList.Add(x);
                    lvAirport.Items.Refresh();                    
                }
            }
        }


        private void miSaveAs_Click(object sender, RoutedEventArgs e)
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
                        foreach (var item in lvAirport.Items)
                        {
                            sw.WriteLine(item.ToString());
                        }
                    }
                }
            }
            isSaved = true;
        }

        private void miExit_Click(object sender, RoutedEventArgs e)
        {
            if (lvAirport.Items.Count >= 1 && isSaved == false)
            {
                var result = MessageBox.Show("Are you sure you want to exit without saving", "Exit confirmation",
               MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (result == MessageBoxResult.Yes)
                {
                    Environment.Exit(0);
                }
                else if (result == MessageBoxResult.No)
                {
                    miSaveAs_Click(sender, e);
                }
            }
            Environment.Exit(0);
        }

        private void tbCode_LostFocus(object sender, RoutedEventArgs e)
        {
            bool isError = false;
            if (tbCode.Text.Length > 3 || tbCode.Text.Length < 3)
            {
                isError = true;
            }
            bool isUpper = false;
            for (int i = 0; i < tbCode.Text.Length; i++)
            {
                if (Char.IsUpper(tbCode.Text[i]))
                {
                    isUpper = true;
                }
            }
            if (isUpper == false) isError = true;
          lbCodeError.Visibility = isError ? Visibility.Visible : Visibility.Hidden;
        }

        private void tbCity_LostFocus(object sender, RoutedEventArgs e)
        {
            bool isError = false;
            if (tbCity.Text.Length < 2 || tbCity.Text.Length > 50)
            {
                isError = true;                
            }
            lbCityError.Visibility = isError ? Visibility.Visible : Visibility.Hidden;
        }

        private void tbLat_LostFocus(object sender, RoutedEventArgs e)
        {
            bool isError = false;
            if (tbLat.Text.Length < 2 )
            {
                isError = true;
            }
            Regex regex = new Regex("./d+");
            
            if(e.Handled = regex.IsMatch(tbLat.Text))
            {
                isError = true;
            }
            lbLatError.Visibility = isError ? Visibility.Visible : Visibility.Hidden;
        }

        private void tbLog_LostFocus(object sender, RoutedEventArgs e)
        {
            bool isError = false;
            if (tbLog.Text.Length < 2)
            {
                isError = true;
            }
            Regex regex = new Regex("./d+");

            if (e.Handled = regex.IsMatch(tbLog.Text))
            {
                isError = true;
            }
            lbLogError.Visibility = isError ? Visibility.Visible : Visibility.Hidden;
        }      

        private void miDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvAirport.SelectedIndex == -1) return;
            if(lvAirport.SelectedItems.Count >= 1)
            {
                foreach(var val in lvAirport.SelectedItems)
                {
                    Airport x = val as Airport;
                    var result = MessageBox.Show("Are you sure you want to delete this item?\n" + x, "Delete confirmation",
                    MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.Cancel);
                    if (result == MessageBoxResult.OK)
                    {
                        airpotList.Remove(x);
                        
                    }
                }
            }
            lvAirport.Items.Refresh();
            resetFields();
            lblID.Content = "";


        }

        private void miSaveSel_Click(object sender, RoutedEventArgs e)
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
                        foreach (var item in lvAirport.SelectedItems)
                        {
                            sw.WriteLine(item.ToString());
                        }
                    }
                }
            }
            isSaved = true;
        }
    }
}

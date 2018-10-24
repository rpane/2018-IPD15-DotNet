using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace Day09Travel
{
    /// <summary>
    /// Interaction logic for AddEditDialog.xaml
    /// </summary>
    public partial class AddEditDialog : Window
    {
        private Trip currTrip;
        public AddEditDialog(Window parent, Trip __currTrip = null)
        {
            InitializeComponent();
            Owner = parent;
            currTrip = __currTrip;
            if(currTrip != null)
            {
                lblID.Content = currTrip.Id + "";
                tbDestination.Text = currTrip.Destination;
                tbName.Text = currTrip.Name;
                tbPassport.Text = currTrip.PassportNo;
                dpDep.Text = currTrip.Departure.ToString();
                dpReturn.Text = currTrip.ReturnDate.ToString();
                cbTransport.Text = currTrip.Transport.ToString();
            }
        }

        private void btnAddTrip_Click(object sender, RoutedEventArgs e)
        {
            string dest = tbDestination.Text;
            string name = tbName.Text;
            string passPort = tbPassport.Text;
            DateTime depDate = DateTime.Parse(dpDep.Text);
            DateTime retDate = DateTime.Parse(dpReturn.Text);
            if(retDate.Date < depDate.Date)
            {
                MessageBox.Show("Invalid Return Date. Needs to be after Departure");
                return;
            }
            string trans = cbTransport.Text;

            Trip.TransportEnum transport;
            if(!Enum.TryParse<Trip.TransportEnum>(trans, out transport))
            {
                throw new InvalidCastException("Enum value invalid: " + trans);
            }
            try
            {
                if (currTrip == null)
                {
                    Trip t = new Trip(dest, name, passPort, depDate, retDate, transport);
                    Globals.db.AddPerson(t);
                }
                else
                {
                    currTrip.Destination = dest;
                    currTrip.Name = name;
                    currTrip.PassportNo = passPort;
                    currTrip.Departure = depDate;
                    currTrip.ReturnDate = retDate;
                    currTrip.Transport = transport;
                }
                this.DialogResult = true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(this, ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

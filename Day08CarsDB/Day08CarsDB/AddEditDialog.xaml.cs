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

namespace Day08CarsDB
{
    /// <summary>
    /// Interaction logic for AddEditDialog.xaml
    /// </summary>
    public partial class AddEditDialog : Window
    {
        private Cars currCar;       
        public AddEditDialog(Window parent, Cars _currCar = null)
        {
           
            InitializeComponent();
            Owner = parent;

            currCar = _currCar;
            if(currCar != null)
            {
                lblID.Content = currCar.Id;
                tbMakeModel.Text = currCar.MakeModel;
                sldEngineSize.Value = currCar.EngineSize;
                cbFuel.Text = currCar.FuelType;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string makeModel = tbMakeModel.Text;
            double engineSize = sldEngineSize.Value;
            string fuelType = cbFuel.Text;

            try
            {
                if(currCar == null)
                {
                    Cars c = new Cars(makeModel, engineSize, fuelType);
                    Globals.db.AddCar(c);                    
                }
                else
                {
                    currCar.MakeModel = makeModel;
                    currCar.EngineSize = engineSize;
                    currCar.FuelType = fuelType;
                    Globals.db.UpdateCar(currCar);
                }

                this.DialogResult = true;
            }catch (SqlException ex)
            {
                MessageBox.Show(this, ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        
    }
}

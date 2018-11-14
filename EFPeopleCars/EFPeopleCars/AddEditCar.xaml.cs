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
using System.Windows.Shapes;

namespace EFPeopleCars
{
    /// <summary>
    /// Interaction logic for AddEditCar.xaml
    /// </summary>
    public partial class AddEditCar : Window
    {
        private Car currCar;
        public AddEditCar(Window parent, Car _currCar = null)
        {
            InitializeComponent();
            Owner = parent;
            currCar = _currCar;

        }

        private void btnSaveCar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancelCar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

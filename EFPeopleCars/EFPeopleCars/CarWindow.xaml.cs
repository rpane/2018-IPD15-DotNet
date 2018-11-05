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
    /// Interaction logic for CarWindow.xaml
    /// </summary>
    public partial class CarWindow : Window
    {
        private Car currCar;
        public CarWindow(Window parent, Car _currCar = null)
        {
            InitializeComponent();
            Owner = parent;
            currCar = _currCar;
        }
        void RefreshList()
        {
            using (PeopleCarsContext ctx = new PeopleCarsContext())
            {
                lvCars.ItemsSource = ctx.Cars.ToList();
            }
        }
        private void miAddCar_Click(object sender, RoutedEventArgs e)
        {
            AddEditCar aec = new AddEditCar(this);
            aec.ShowDialog();
            RefreshList();
        }

        private void lvCars_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AddEditCar aec = new AddEditCar(this);
            aec.ShowDialog();
            RefreshList();
        }

        private void miDeleteCar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

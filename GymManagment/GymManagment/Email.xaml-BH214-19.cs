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

namespace GymManagment
{
    /// <summary>
    /// Interaction logic for Email.xaml
    /// </summary>
    public partial class Email : Window
    {
        public Email(Window parent)
        {
            InitializeComponent();
            Owner = parent;
        }
        private void rbMembers_Checked(object sender, RoutedEventArgs e)
        {
            cbMembers.Visibility = Visibility.Visible;
            lblMem.Visibility = Visibility.Visible;
        }

    }

}

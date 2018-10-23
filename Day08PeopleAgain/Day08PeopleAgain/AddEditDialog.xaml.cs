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

namespace Day08PeopleAgain
{
    /// <summary>
    /// Interaction logic for AddEditDialog.xaml
    /// </summary>
    public partial class AddEditDialog : Window
    {
        private Person currPerson; // null when adding
        public AddEditDialog(Window parent, Person __currPerson = null)
        {
            InitializeComponent();
            Owner = parent;
            //
            currPerson = __currPerson;
            if (currPerson != null)
            {
                lblId.Content = currPerson.Id + "";
                tbName.Text = currPerson.Name;
                tbAge.Text = currPerson.Age + "";
            }
        }

        private void Button_CancelClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Button_SaveClick(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            int age;
            if (!int.TryParse(tbAge.Text, out age))
            {
                MessageBox.Show("Age must be an integer value");
                return;
            }
            // FIXME: do a better job at verifying input values
            try
            {
                if (currPerson == null)
                {
                    Person p = new Person() { Name = name, Age = age };
                    Globals.db.AddPerson(p);
                }
                else
                {
                    currPerson.Name = name;
                    currPerson.Age = age;
                    Globals.db.UpdatePerson(currPerson);
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

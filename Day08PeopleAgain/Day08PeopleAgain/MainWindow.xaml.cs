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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Day08PeopleAgain
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
        void RefreshList()
        {
            try
            {
                List<Person> list = Globals.db.GetAllPeople();
                lvPeople.ItemsSource = list;
                // no need to do Refresh if we assign to ItemsSource
            }
            catch (SqlException ex)
            {
                MessageBox.Show(this, ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MenuItem_AddPersonClick(object sender, RoutedEventArgs e)
        {
            AddEditDialog dlg = new AddEditDialog(this);
            if (dlg.ShowDialog() == true)
            {
                RefreshList();
                MessageBox.Show("Success!");
            }
        }

        private void lvPeople_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Person currPerson = lvPeople.SelectedItem as Person;
            if (currPerson == null) return;

            AddEditDialog dlg = new AddEditDialog(this, currPerson);
            if (dlg.ShowDialog() == true)
            {
                RefreshList();
                MessageBox.Show("Success!");
            }
        }

        private void MenuItem_DeleteClick(object sender, RoutedEventArgs e)
        {
            Person currPerson = lvPeople.SelectedItem as Person;
            if (currPerson == null) return;
            //
            MessageBoxResult result = MessageBox.Show(this, "Are you sure you want to delete:\n" +
                currPerson, "Confirm delete", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            //
            if (result == MessageBoxResult.OK)
            {
                try
                {
                    Globals.db.DeletePerson(currPerson.Id);
                    RefreshList();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(this, ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}

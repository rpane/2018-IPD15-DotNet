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

namespace Day08PeopleAgain
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /******************* Delegate ********************/
        public delegate void StatusUpdater(String str);
        public StatusUpdater UpdateStatus;

        public void UpdateStatusBar(String msg)
        {
            tbStatus.Text = msg;
        }

        public void SaveStatusHistoryToFileWithTimestamp(String status)
        {
            string ts = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            File.AppendAllText("status.txt", ts + " "+status+ "\n");
        }

        /************************************************/
        public MainWindow()
        {
            UpdateStatus = UpdateStatusBar;
            UpdateStatus += SaveStatusHistoryToFileWithTimestamp;

            try
            {
                InitializeComponent();
                Globals.db = new Database();
                RefreshList();
                if(UpdateStatus != null)
                {
                    UpdateStatus("Program Started");
                }
                
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
                UpdateStatus("Added Person");
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
                UpdateStatus("Person Updated");
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
                    UpdateStatus("Person Deleted");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(this, ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void miSortID_Click(object sender, RoutedEventArgs e)
        {
            List<Person> list = Globals.db.GetAllPeople();
            List<Person> sorted = list.OrderBy(Person => Person.Id).ToList(); 
            lvPeople.ItemsSource = sorted;
            UpdateStatus("Sorted by ID");
        }

        private void miSortName_Click(object sender, RoutedEventArgs e)
        {
            List<Person> list = Globals.db.GetAllPeople();
            List<Person> sorted = list.OrderBy(Person => Person.Name).ToList();
            lvPeople.ItemsSource = sorted;
            UpdateStatus("Sorted by Name");
        }

        private void miSortAge_Click(object sender, RoutedEventArgs e)
        {
            List<Person> list = Globals.db.GetAllPeople();
            List<Person> sorted = list.OrderBy(Person => Person.Age).ToList();
            lvPeople.ItemsSource = sorted;
            UpdateStatus("Sorted by Age");
        }
              
        
    }
}

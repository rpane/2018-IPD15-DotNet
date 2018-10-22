using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Day08NewPeopleDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database db;        

        public MainWindow()
        {
            try { 
            InitializeComponent();
            db = new Database();
            }catch(SqlException ex)
            {
                MessageBox.Show(this, "Error connecting to database\n" + ex.Message, "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(1);
            }
            lvPeople.ItemsSource = db.GetAllPeople();
        }
    
        private void miDelete_Click(object sender, RoutedEventArgs e)
        {
            Person x = lvPeople.SelectedItem as Person;
            var result = MessageBox.Show("Are you sure you want to delete this item?\n" + x, "Delete confirmation",
               MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.Cancel);
            if (result == MessageBoxResult.OK)
            {
                db.DeletePerson(x.Id);
                
            }
            
            refreshLV();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            int age = int.Parse(tbAge.Text);
            double height = slidHeight.Value;
            Person x = new Person(name, age, height);
            db.AddPerson(x);            
            refreshLV();

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Person z = lvPeople.SelectedItem as Person;
            z.Name = tbName.Text;
            z.Age = int.Parse(tbAge.Text);
            z.Height = slidHeight.Value;           
            db.UpdatePerson(z);
            refreshLV();
        }

        void refreshLV()
        {

            tbAge.Text = "";
            tbName.Text = "";
            slidHeight.Value = 165;
            List<Person> list = db.GetAllPeople();
            lvPeople.ItemsSource = list;
                     
        }

        private void lvPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Person x = lvPeople.SelectedItem as Person;
            if (x == null) return;
            lblID.Content = x.Id;
            tbName.Text = x.Name;
            tbAge.Text = x.Age.ToString();
            slidHeight.Value = x.Height;

        }
    }
}

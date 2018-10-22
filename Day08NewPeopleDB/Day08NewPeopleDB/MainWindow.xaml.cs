using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        Database db = new Database();
        

        public MainWindow()
        {

            InitializeComponent();            
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
            lvPeople.Items.Refresh();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            int age = int.Parse(tbAge.Text);
            double height = slidHeight.Value;
            Person x = new Person(name, age, height);
            db.AddPerson(x);
            lvPeople.Items.Refresh();
            refreshLV();

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        public void refreshLV()
        {
            tbAge.Text = "";
            tbName.Text = "";
            slidHeight.Value = 165;            
        }
    }
}

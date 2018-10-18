using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Day05PeopleBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Person> items = new List<Person>();
        public MainWindow()
        {
            InitializeComponent();                     
            lvPeople.ItemsSource = items;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            int age = 0;
            if (!int.TryParse(tbAge.Text, out age))
            {
                MessageBox.Show(this, "Age must be numerical", "Input error");
                return;
            }
            try
            {
                Person p = lvPeople.SelectedItem as Person;
                Person.checkNameValid(name);
                Person.checkAgeValid(age);
                p.Name = name;
                p.Age = age;
                // FIXME: if name is valid but age is not, then partial update will occur
                lvPeople.Items.Refresh(); // give list view a nudge that data changed
                tbName.Text = "";
                tbAge.Text = "";
                lblID.Content = "...";
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(this, ex.Message, "Input error");
                return;
            }
        }
      

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            int age = 0;
            if (!int.TryParse(tbAge.Text, out age))
            {
                MessageBox.Show(this, "Age must be numerical", "Input error");
                return;
            }
            try
            {
                Person.checkNameValid(name);
                Person.checkAgeValid(age);
                Person p = new Person(name, age);
                items.Add(p);
                lvPeople.Items.Refresh(); // give list view a nudge that data changed
                tbName.Text = "";
                tbAge.Text = "";
                lblID.Content = "...";
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(this, ex.Message, "Input error");
                return;
            }
        }

        private void tbAge_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void lvPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Person p = lvPeople.SelectedItem as Person;
            if (p == null) return;
            lblID.Content = p.Id + "";
            tbName.Text = p.Name;
            tbAge.Text = p.Age + "";
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (lvPeople.SelectedIndex == -1) return;
            Person p = lvPeople.SelectedItem as Person;
            var result = MessageBox.Show("Are you sure you want to delete this item?\n" + p, "Delete confirmation",
                MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.Cancel);
            if (result == MessageBoxResult.OK)
            {
                items.Remove(p);
                lvPeople.Items.Refresh();
            }
        }
    }
}

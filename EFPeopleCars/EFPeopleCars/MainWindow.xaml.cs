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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EFPeopleCars
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RefreshList();
        }

        void RefreshList()
        {
            using(PeopleCarsContext ctx = new PeopleCarsContext())
            {    
                    lvPeople.ItemsSource = ctx.People.ToList();                    
            }
        }

        private void miAddPerson_Click(object sender, RoutedEventArgs e)
        {
            AddEditPerson aep = new AddEditPerson(this);
            aep.ShowDialog();
            RefreshList();
        }       

        private void miEditPerCar_Click(object sender, RoutedEventArgs e)
        {     

            CarWindow carWin = new CarWindow(this);
            carWin.ShowDialog();
            RefreshList();

        }

        private void miDelete_Click(object sender, RoutedEventArgs e)
        {
            Person currPerson = lvPeople.SelectedItem as Person;
            if (currPerson == null) return;
            //
            MessageBoxResult result = MessageBox.Show(this, "Are you sure you want to delete:\n" +
                currPerson, "Confirm delete", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            //
            using(PeopleCarsContext ctx = new PeopleCarsContext())
            {
                if (result == MessageBoxResult.OK)
                {
                     var people = (from p in ctx.People where p.Id == currPerson.Id select p).ToList();
                    if (people.Count == 0)
                    {
                        Console.WriteLine("Record not found");
                    }
                    else
                    {
                        Person p = people[0];
                        ctx.People.Remove(p);
                        ctx.SaveChanges();
                        RefreshList();
                    }               
                        
                }
            }
        
        }

        private void lvPeople_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Person currPerson = lvPeople.SelectedItem as Person;
            if (currPerson == null) return;

            AddEditPerson aep = new AddEditPerson(this, currPerson);
            aep.ShowDialog();
            RefreshList();
        }

        private void miEditCar_Click(object sender, RoutedEventArgs e)
        {         
            CarWindow carWin = new CarWindow(this);
            carWin.ShowDialog();
            RefreshList();
        }
    }
}

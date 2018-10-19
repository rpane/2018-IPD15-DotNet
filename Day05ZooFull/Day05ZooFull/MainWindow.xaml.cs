using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace Day05ZooFull
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Animal> animals = new List<Animal>();
        bool isSaved = false;
        public MainWindow()
        {
            InitializeComponent();
            lvSpeciesName.ItemsSource = animals;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string spec = cbSpecies.Text;
            string name = tbName.Text;
            int age = int.Parse(tbAge.Text);
            double weight = double.Parse(tbWeight.Text);
            Animal x = new Animal(name, spec, age, weight);
            animals.Add(x);
            lvSpeciesName.Items.Refresh();
            resetFields();
        }
        public void resetFields()
        {
            cbSpecies.SelectedIndex =0;
            tbName.Text = "";
            tbAge.Text = "";
            tbWeight.Text = "";
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (lvSpeciesName.SelectedIndex == -1)
            {
                MessageBox.Show(this, "Unable to update, nothing selected", "Input error");
                return;
            }

            string name = tbName.Text;
            string spec = cbSpecies.Text;
            int age =0;
            if(!int.TryParse(tbAge.Text, out age))
            {
                MessageBox.Show(this, "Age must be numerical", "Input error");
                return;
            }
            double weight = 0;
            if(!double.TryParse(tbWeight.Text, out weight))
            {
                MessageBox.Show(this, "Weight must be numerical", "Input error");
                return;
            }
            try
            {
                Animal z = lvSpeciesName.SelectedItem as Animal;
                Animal.checkAgeValid(age);
                Animal.checkNameValid(name);
                Animal.checkWeightValid(weight);
                z.Name = name;
                z.Age = age;
                z.Weight = weight;
                z.Species = spec;
                lvSpeciesName.Items.Refresh();
                resetFields();                
            }catch (ArgumentException ex)
            {
                MessageBox.Show(this, ex.Message, "Input error");
                return;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvSpeciesName.SelectedIndex == -1) return;
            Animal x = lvSpeciesName.SelectedItem as Animal;
            var result = MessageBox.Show("Are you sure you want to delete this item?\n" + x, "Delete confirmation",
                MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.Cancel);
            if (result == MessageBoxResult.OK)
            {
                animals.Remove(x);
                lvSpeciesName.Items.Refresh();
                resetFields();
            }
        }

        private void miOpen_Click(object sender, RoutedEventArgs e)
        {
            animals.Clear();            
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open Zoo File";
            ofd.Filter = " ZOO files |*.zoo";
            if (ofd.ShowDialog() == true)
            {
                string filename = ofd.FileName;
                string[] lines = File.ReadAllLines(filename);
                foreach(string line in lines)
                {
                    string[] words = line.Split(';');
                    string name = words[0];
                    string spec = words[1];
                    int age = int.Parse(words[2]);
                    double weight = double.Parse(words[3]);
                    Animal.checkAgeValid(age);
                    Animal.checkNameValid(name);
                    Animal.checkWeightValid(weight);
                    Animal.checkSpeciesValid(spec);
                    Animal x = new Animal(name, spec, age, weight);
                    animals.Add(x);                   
                    lvSpeciesName.Items.Refresh();
                }

            }
        }

        private void miSaveAs_Click(object sender, RoutedEventArgs e)
        {
            isSaved = true;
            string filename = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Zoo File (.zoo) | *.zoo";
            sfd.Title = "Save a Zoo File";
            sfd.DefaultExt = ".zoo";
            if (sfd.ShowDialog() == true)
            {
                filename = sfd.FileName.ToString();
                if (filename != "")
                {
                    using (StreamWriter sw = new StreamWriter(filename))
                    {
                        foreach (var item in lvSpeciesName.Items)
                        {
                            sw.WriteLine(item.ToString());
                        }
                    }
                }
            }
        }

        private void miExit_Click(object sender, RoutedEventArgs e)
        {
            if (lvSpeciesName.Items.Count >=1 && isSaved == false)
            {
                var result = MessageBox.Show("Are you sure you want to exit without saving","Exit confirmation",
               MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (result == MessageBoxResult.Yes)
                {
                    Environment.Exit(0);
                }else if (result == MessageBoxResult.No)
                {
                    miSaveAs_Click(sender, e);
                }
            }
            Environment.Exit(0);
        }       

        private void MenuItem_DeleteClick(object sender, RoutedEventArgs e)
        {
            if (lvSpeciesName.SelectedIndex == -1) return;
            Animal x = lvSpeciesName.SelectedItem as Animal;
            var result = MessageBox.Show("Are you sure you want to delete this item?\n" + x, "Delete confirmation",
                MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.Cancel);
            if (result == MessageBoxResult.OK)
            {
                animals.Remove(x);
                lvSpeciesName.Items.Refresh();
                resetFields();
            }
        }

        private void lvSpeciesName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Animal x = lvSpeciesName.SelectedItem as Animal;
            if (x == null) return;
            cbSpecies.Text = x.Species;
            tbName.Text = x.Name;
            tbAge.Text = x.Age.ToString();
            tbWeight.Text = x.Weight.ToString();

        }
    }
}

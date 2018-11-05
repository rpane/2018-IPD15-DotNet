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
    /// Interaction logic for AddEditPerson.xaml
    /// </summary>
    public partial class AddEditPerson : Window
    {
        private Person currPerson;
        public AddEditPerson(Window parent, Person _currPerson = null)
        {
            InitializeComponent();
            Owner = parent;
            currPerson = _currPerson;
            if(currPerson != null)
            {
                lblID.Content = currPerson.Id + "";
                tbName.Text = currPerson.Name;
                tbAge.Text = currPerson.Age + "";
                cbGender.Text = currPerson.Gender +"";
            }
        }

        private void btnSavePerson_Click(object sender, RoutedEventArgs e)
        {
            using(PeopleCarsContext ctx = new PeopleCarsContext())
            {

            
            string name = tbName.Text;
            int age = int.Parse(tbAge.Text);
            string genderStr = cbGender.Text;

            Person.GenderEnum gender;
            if(!Enum.TryParse<Person.GenderEnum>(genderStr, out gender))
            {
                throw new InvalidCastException("Enum value invalid: " + genderStr);
            }
            
            if(currPerson == null)
            {
                Person p = new Person { Name = name, Age = age, Gender = gender};
                    ctx.People.Add(p);
                    ctx.SaveChanges();
                }
                else
                {
                    var people = (from p in ctx.People where p.Id == currPerson.Id select p).ToList();
                    if(people.Count == 0)
                    {
                        Console.WriteLine("Record not found");
                    }
                    else
                    {
                        Person p = people[0];
                        
                        p.Name = name;
                        p.Age = age;
                        p.Gender = gender;
                        ctx.SaveChanges();
                    }                  
                    
                }
                this.DialogResult = true;
            }
        }

        private void btnCancelPerson_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

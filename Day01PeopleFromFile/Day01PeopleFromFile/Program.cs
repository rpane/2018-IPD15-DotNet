using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01PeopleFromFile
{
    class Person
    {
        public string Name;
        public int Age;
        public double Height;

        public override string ToString()
        {
            return string.Format("{0} is {1} y/o, with a height of {2}",Name,Age,Height);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            try
            {
                string[] lineArray = File.ReadAllLines(@"..\..\..\people.txt");
                foreach (string line in lineArray)
                {
                    string[] split = line.Split(";");
                    Person p = new Person() { Name = split[0], Age = int.Parse(split[1]), Height = double.Parse(split[2])};
                    people.Add(p);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex);
            }

            foreach(Person val in people)
            {
                Console.WriteLine(val);
            }
            Console.WriteLine("************************************");
            SortbyName(people);
            SortbyAge(people);
            SortbyNameHeight(people);
            FindYoungest(people);
            FindTallest(people);
            GroupByNames(people);
            NameBeginsWith(people);
            peopleHeightBetween(people);
            Console.ReadKey();
        }

        static void SortbyName(List<Person> people)
        {
            Console.WriteLine("Sorted by Name------------------------");
            List<Person> sorted = people.OrderBy(Person => Person.Name).ToList();
            /*
             * var peopleByName = from p in people orderby p.name select p;
             * */

            foreach(Person x in sorted)
            {
                Console.WriteLine(x);
            }
        }
        static void SortbyAge(List<Person> people)
        {
            Console.WriteLine("Sorted by Age------------------------");
            List<Person> sorted = people.OrderBy(Person => Person.Age).ToList();
            foreach (Person x in sorted)
            {
                Console.WriteLine(x);
            }

        }
        static void SortbyNameHeight(List<Person> people)
        {
            Console.WriteLine("Sorted by Name and Height----------------");            
            List<Person> sorted = people.OrderBy(Person => Person.Name).ThenBy(Person => Person.Height).ToList();
            foreach (Person x in sorted)
            {
                Console.WriteLine(x);
            }
        }

        static void FindYoungest(List<Person> people)
        {
            Console.WriteLine("--------------------Youngest Person---------------");
            var youngest = people.Min(Person => Person.Age);
            Console.WriteLine(youngest);
        }

        static void FindTallest(List<Person> people)
        {
            Console.WriteLine("--------------------Tallest Person---------------");
            var tallest = people.Max(Person => Person.Height);
            Console.WriteLine(tallest);
        }
        static void GroupByNames(List<Person> people)
        {
            Console.WriteLine("--------------------Number of people with the same name---------------");
            /**
             * var numNames = (from p in people group p by p.Name).OrderBy(g => -g.Count());
             * */

            var numNames = from Person in people
                           group Person by Person.Name into g
                           let count = g.Count()
                           orderby count descending
                           select new { Value = g.Key, Count = count };
            foreach(var x in numNames)
            {
                Console.WriteLine(x.Value + " - " + x.Count);
            }                          
            
        }
        static void NameBeginsWith(List<Person> people)
        {
            Console.WriteLine("--------------------Names begining with J---------------");
            var startWithJ = people.Where(Person => Person.Name.StartsWith("J"));
            foreach(var x in startWithJ)
            {
                Console.WriteLine(x.Name);
            }
        }
        static void peopleHeightBetween(List<Person> people)
        {
            Console.WriteLine("--------------------Height between 180-200---------------");
            var heightBet = people.Where(Person => Person.Height >=180 & Person.Height <=200);
            foreach (var x in heightBet)
            {
                Console.WriteLine(x.Name+" has the height of "+x.Height);
            }
        }
    }
}

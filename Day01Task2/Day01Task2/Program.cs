using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01Task2
{
    class Person
    {
        public string name;
        public int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public override string ToString()
        {
            return name+" is "+ age;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> People = new List<Person>();
            try
            {
                string[] lines = File.ReadAllLines(@"E:\C#\2018-IPD15-DotNet\people.txt");
                
                foreach (string line in lines)
                {
                    string[] words = line.Split(';');
                    string name = words[0];
                    int age = int.Parse(words[1]);
                    Person e = new Person(name,age);
                    People.Add(e);
                                      
                }
            }catch(IOException ex)
            {
                Console.WriteLine(ex);
            }         

            foreach(var v in People)
            {
                Console.WriteLine(v.ToString());
            }
            
            Console.WriteLine("============Sorted by name=============");
           
            People.Sort(delegate (Person p1, Person p2) { return p1.name.CompareTo(p2.name); });

            foreach (var v in People)
            {
                Console.WriteLine(v.ToString());
            }
            Console.ReadKey();
            
        }

       
        
    }
}

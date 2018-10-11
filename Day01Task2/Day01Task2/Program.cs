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
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> People = new List<Person>();
            try
            {
                string[] lines = File.ReadAllLines("people.txt");

                foreach (string line in lines)
                {
                    string name =;
                    int age =;
                    Person e = new Person() { name = "abc", age = 23 };
                    People.Add(e);
                    e.ToString();
                }
            }catch(IOException ex)
            {
                Console.WriteLine(ex);
            }
            People.Sort();
            Console.WriteLine("============Sorted by name=============");
            Console.ReadKey();
            
        }

       
        
    }
}

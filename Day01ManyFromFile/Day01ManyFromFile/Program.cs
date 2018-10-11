using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01ManyFromFile
{
    class Program
    {
      abstract class Person
        {
            String Name;
            int Age;

            public virtual string ToString()
            {
                return base.ToString();
            }
        }
        class Student : Person
        {
            String Program;
            Double GPA;
            public override string ToString()
            {
                return base.ToString();
            }
        }

        class Teacher : Person
        {
            String Subject;
            int YOP; // Years Of Experience Teaching
            public override string ToString()
            {
                return base.ToString();
            }
        }
        static void Main(string[] args)
        {
            List<Person> People = new List<Person>();
            try
            {
                string[] lines = File.ReadAllLines(@"E:\C#\2018-IPD15-DotNet\Day01ManyFromFile\many.txt");
                foreach (string line in lines)
                {
                    string[] words = line.Split(';');
                   
                    //People.Add(e);

                }
            }
            catch (IOException ex)
            {

            }
            Console.ReadKey();
        }

    }
}

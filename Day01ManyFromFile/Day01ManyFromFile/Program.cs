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
            public String Name;
            public int Age;

            public virtual string ToString()
            {
                return Name+" is "+Age+" y/o";
            }
        }
        class Student : Person
        {
            String Program;
            Double GPA;
            public override string ToString()
            {
                return Name + " is " + Age + " y/o, studing in "+Program+" with a "+GPA+" GPA";
            }
        }

        class Teacher : Person
        {
            String Subject;
            int YOP; // Years Of Experience Teaching
            public override string ToString()
            {
                return Name + " is " + Age + " y/o, and has been teaching "+Subject+" for "+YOP+" years";
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

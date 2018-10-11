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
      class Person
        {
            public String Name;
            public int Age;

            public virtual string ToString()
            {
                return Name+" is a person "+Age+" y/o.";
            }
        }
        class Student : Person
        {
            public String Program;
            public Double GPA;
            public override string ToString()
            {
                return Name + " is a student " + Age + " y/o, studying in "+Program+" with a "+GPA+" GPA.";
            }
        }

        class Teacher : Person
        {
            public String Subject;
            public int YOP; // Years Of Experience Teaching
            public override string ToString()
            {
                return Name + " is a teacher " + Age + " y/o, and has been teaching "+Subject+" for "+YOP+" years.";
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
                    if (words[0] == "Person")
                    {
                        Person e = new Person() { Name = words[1], Age = int.Parse(words[2]) };
                        People.Add(e);
                    }
                    else if (words[0] == "Student")
                    {
                        Person e = new Student() { Name = words[1], Age = int.Parse(words[2]), Program = words[3], GPA = double.Parse(words[4]) };
                        People.Add(e);
                    }
                    else if (words[0] == "Teacher")
                    {
                        Person e = new Teacher() { Name = words[1], Age = int.Parse(words[2]), Subject = words[3], YOP = int.Parse(words[4]) };
                        People.Add(e);
                    }


                }
            }
            catch (IOException ex)
            {
                Console.Write(ex);
            }
            foreach (var v in People)
            {
                Console.WriteLine(v.ToString());
            }
            Console.ReadKey();
        }

    }
}

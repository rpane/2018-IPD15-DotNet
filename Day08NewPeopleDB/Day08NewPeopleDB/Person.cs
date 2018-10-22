using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08NewPeopleDB
{
    class Person
    {
        int id;
        string name;
        int age;
        double height;

        public Person(string name, int age, double height)
        {
            
            this.Name = name;
            this.Age = age;
            this.Height = height;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public double Height { get => height; set => height = value; }

        public override string ToString()
        {
            return Id+","+Name+","+Age+","+Height;
        }
    }
}

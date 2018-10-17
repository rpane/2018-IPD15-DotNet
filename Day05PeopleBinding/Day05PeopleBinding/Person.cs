using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05PeopleBinding
{
    class Person
    {
        static int id = 10;
        string name;
        int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public static int Id { get => id++; }

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }

    }
}

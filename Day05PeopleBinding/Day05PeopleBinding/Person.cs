using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05PeopleBinding
{
    class Person
    {
        private static int count;//Total count of ids
        string name;
        int age;
        int id;//Id

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            id = ++count;
        }
        
        public int Id
        {
            get
            {
                return id;
            }
        }

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }

    }
}

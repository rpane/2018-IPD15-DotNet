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

        public static void checkNameValid(string name)
        {
            if (name.Length < 2 || name.Length > 50)
            {
                throw new ArgumentOutOfRangeException("Name must be 2-50 characters long");
            }
        }

        public static void checkAgeValid(int age)
        {
            if (age < 1 || age > 150)
            {
                throw new ArgumentOutOfRangeException("Age must be 1-150");
            }
        }

        override public String ToString()
        {
            return string.Format("{0}: {1} is {2}", Id, Name, Age);
        }
    }
}

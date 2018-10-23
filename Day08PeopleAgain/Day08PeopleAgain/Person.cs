using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08PeopleAgain
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public GenderEnum Gender { get; set; }

        public enum GenderEnum { NA ,Female,Male};

        public override string ToString()
        {
            return string.Format("{0}: {1} is {2} y/o {3}", Id, Name, Age, Gender);
        }
    }
}

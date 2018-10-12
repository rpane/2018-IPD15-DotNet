using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01ManyFromFile
{
    class Person
    {
        public String Name;
        public int Age;

        public virtual string ToString()
        {
            return Name + " is a person " + Age + " y/o.";
        }
    }
    class Student : Person
    {
        public String Program;
        public Double GPA;
        public override string ToString()
        {
            return Name + " is a student " + Age + " y/o, studying in " + Program + " with a " + GPA + " GPA.";
        }
    }

    class Teacher : Person
    {
        public String Subject;
        public int YOP; // Years Of Experience Teaching
        public override string ToString()
        {
            return Name + " is a teacher " + Age + " y/o, and has been teaching " + Subject + " for " + YOP + " years.";
        }
    }
}

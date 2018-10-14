using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01ManyFromFile
{
    class Person
    {      
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        private String _name;
        public String Name
        {
            get { return _name; }
            set
            {
                if (value.Length < 1)
                {
                    throw new InvalidDataException("Name too short");
                }
                _name = value;
            }
        }
        private int _age;
        public int Age
        {
            get {return _age; }
            set
            {
                if(value <1)
                {
                    throw new InvalidDataException("Age needs to be above 0");
                }
                _age = value;
            }
        }

        public virtual string ToString()
        {
            return Name + " is a person " + Age + " y/o.";
        }
    }
    class Student : Person
    {  
        public Student(string name, int age, string program, double gPA) : base(name,age)
        {
            Program = program;
            GPA = gPA;
        }
        private String _program;
        public String Program
        {
            get
            {
                return _program;
            }
            set
            {
                if (value.Length <1)
                {
                    throw new InvalidDataException("Program name too short");
                }
                _program = value;
            }
        }
        private Double _gpa;
        public Double GPA
        {
            get
            {
                return _gpa;
            }
            set
            {
                if(value < 1)
                {
                    throw new InvalidDataException("GPA is too low, must be above 20");
                }
                _gpa = value;
            }
        }

        public override string ToString()
        {
            return Name + " is a student " + Age + " y/o, studying in " + Program + " with a " + GPA + " GPA.";
        }
    }

    class Teacher : Person
    {
        public Teacher(string name, int age, string subject, int yOP) : base(name, age)
        {
            Subject = subject;
            YOP = yOP;
        }
        private String _subject;
        public String Subject
        {
            get
            {
                return _subject;
            }
            set
            {
                if (value.Length <1)
                {
                    throw new InvalidDataException("Subject name too short");
                }
                _subject = value;
            }
        }
        private int _yop;
        public int YOP
        {
            get
            {
                return _yop;
            }
            set
            {
                if (value <0)
                {
                    throw new InvalidDataException("Teaching years needs to be a positive value");
                }
                _yop = value;
            }
        }

        public override string ToString()
        {
            return Name + " is a teacher " + Age + " y/o, and has been teaching " + Subject + " for " + YOP + " years.";
        }
    }
}

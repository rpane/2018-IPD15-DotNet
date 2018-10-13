using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02StudentsGrades
{
    class Student
    {
        public Student(string name)
        {
            _name = name;
        }
        private string _name;
	    public string Name
        { // no setter
            get
            {
                return _name;
            }
        }
        private List<double> gradeList= new List<double>();
        
        public void addGrade(double grade)
        {
            gradeList.Add(grade);
        }
        
        public double Average
        { // no setter
            get
            {
                // compute average here and return
                return gradeList.Average();
            }
        }

        public override string ToString()
        {
            return _name+" has GPA "+Average; 
        }
    }
}

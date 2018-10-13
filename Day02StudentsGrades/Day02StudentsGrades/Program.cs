using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02StudentsGrades
{
    class Program
    {
        static List<Student> studentList = new List<Student>();
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"..\..\grades.txt");
            foreach (string line in lines)
            {
                string[] words = line.Split(':');
                string[] grades = words[1].Split(',');
                string name = words[0];

                Student a = new Student(name);
                studentList.Add(a);
                foreach(string val in grades)
                {
                    double grade = letterToGpa(val);
                    a.addGrade(grade);

                }                
            }
            foreach(var v in studentList)
            {
                Console.WriteLine(v.ToString());
            }
            Console.ReadKey();
        }

        /*
        static double letterToNumberGrade(string strGrade)
        {
        }*/

        public static double letterToGpa(String letter)
        {
            switch (letter)
            {
                case "A+": return 4.33;
                    break;
                case "A": return 4.0;
                    break;
                case "A-": return 3.67;
                    break;
                case "B+": return 3.33;
                    break;
                case "B": return 3;
                    break;
                case "B-": return 2.67;
                    break;
                case "C+": return 2.33;
                    break;
                case "C": return 2;
                    break;
                case "C-": return 1.67;
                    break;
                case "D+": return 1.33;
                    break;
                case "D": return 1;
                    break;
                case "D-": return 0.67;
                    break;
                case "F": return 0;
                    break;
                default:
                    throw new InvalidDataException("Invalid Grade");

	        }
        }
    }
}

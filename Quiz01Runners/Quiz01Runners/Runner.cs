using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz01Runners
{
    class Runner
    {
        string name;
        double avgTime;
        public List<double> runtimesList = new List<double>();

        public Runner(String name) { Name = name; }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if(name == null)
                {
                    name = value;
                }
                else if (name.Length < 2 || name.Length > 20)
                {
                    throw new InvalidDataException("Name is either too short or too long");
                }
                else
                {
                    name = value;
                }
                
            }
        }
        public double AvgTime
        {
            get
            {
                return avgTime;
            }
            set
            {
                if (avgTime < 0)
                {
                    throw new InvalidDataException("Cannot have a negative time");
                }
                avgTime = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz01Runners
{
    class Program
    {
        static List<Runner> runnerList = new List<Runner>();
        static void Main(string[] args)
        {
            try
            {
                string[] lines = File.ReadAllLines(@"..\..\runners.txt");

                bool result;
                double value;
                Runner currentRunner = null;
                foreach (string line in lines)
                {
                    if (line == "")
                    {
                        Console.WriteLine("Name must not be empty, skipping name");
                        continue;
                    }
                    result = double.TryParse(line, out value);
                    if (result == false) //Means its a name
                    {
                        currentRunner = new Runner(line);
                        runnerList.Add(currentRunner);
                    }

                    else if (result == true) // Means its a number
                    {
                        if (currentRunner == null)
                        {
                            Console.WriteLine("Illegal start of file with number instead of name");
                            continue;
                            // throw new IOException("Illegal start of file with number instead of name");
                        }
                        if (value < 0)
                        {
                            Console.WriteLine("Runtime must not be negative");
                            continue;
                        }
                        currentRunner.runtimesList.Add(value);
                    }

                }
                displayRunnerAverages();
                displayAverageForAllRunners();
                displayFastestTime();
                displayNumberOfRunsPerRunner();
                Console.WriteLine("There were {0} runners", runnerList.Count);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadKey();

        }
        private static void displayNumberOfRunsPerRunner()
        {
            foreach (Runner r in runnerList)
            {
                Console.WriteLine("Runners {0} ran {1} times", r.Name, r.runtimesList.Count);
            }
        }

        private static void displayFastestTime()
        {
            double fastest = double.MaxValue;
            foreach (Runner r in runnerList)
            {
                foreach (double time in r.runtimesList)
                {
                    if (time < fastest)
                    {
                        fastest = time;
                    }
                }
            }
            Console.WriteLine("Best runtime of all runners is {0:0.00}", fastest);
        }

        private static void displayAverageForAllRunners()
        {
            double sum = 0;
            int count = 0;
            foreach (Runner r in runnerList)
            {
                foreach (double time in r.runtimesList)
                {
                    sum += time;
                    count++;
                }
            }
            Console.WriteLine("Averate runtime for all runners is {0:0.00}", sum / count);
        }

        private static void displayRunnerAverages()
        {
            foreach (Runner r in runnerList)
            {
                if (r.runtimesList.Count > 0)
                {
                    double sum = 0;
                    foreach (double time in r.runtimesList)
                    {
                        sum += time;
                    }
                    r.AvgTime = sum / r.runtimesList.Count;
                }
                Console.WriteLine("Runner {0} has average runtime {1:0.00}", r.Name, r.AvgTime);
            }
        }
    }
}

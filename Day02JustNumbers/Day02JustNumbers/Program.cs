using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02JustNumbers
{
    class Program
    {
        static List<int> numbers= new List<int>();
        static void Main(string[] args)
        {
            Boolean flag = false;
            
            while (flag != true)
            {
                Console.WriteLine("Please enter a number, or 0 to stop");
                String val = Console.ReadLine();
                int intNum = int.Parse(val);
                if (intNum <= 0 )
                {
                    flag = true;
                    continue;
                }
                numbers.Add(intNum);                
            }
            Console.WriteLine("Average is: "+numbers.Average());
            Console.WriteLine("Max Value is: " + numbers.Max());
            numbers.Sort();
            int middle = numbers.ElementAt(numbers.Count() / 2);
            Console.WriteLine("Median is: " + middle);
            double avrg = numbers.Average();
            double std = Math.Sqrt(numbers.Average(v => Math.Pow(v - numbers.Average(), 2)));
            Console.WriteLine("Standard deviation is: " + std);
            toFile(avrg,numbers.Max(),middle,std);
            Console.ReadKey();

        }
        public static void toFile(double avrg, int max, int mid, double std)
        {
            String text = String.Format("{0};{1};{2};{3}",avrg,max,mid,std);
            System.IO.File.WriteAllText(@"C:\Users\Public\TestFolder\output.txt", text);
        }
        
    }
}

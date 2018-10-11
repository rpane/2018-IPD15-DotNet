using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name");
            String name = Console.ReadLine();
            Console.WriteLine("Enter your age");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Hi {0}, you are {1} y/o", name, age);
            if(age < 18)
            {
                Console.WriteLine("You are not an adult yet");
            }
            Console.ReadKey();
        }
    }
}

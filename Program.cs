using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your name");
            String name = Console.ReadLine();
            Console.WriteLine("Whats is your age?");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Hi " + name + ", you are " + age + " y/o.");

            if (age < 18)
            {
                Console.WriteLine("You are not an adult yet");
            }
            Console.ReadLine();
        }
    }
}

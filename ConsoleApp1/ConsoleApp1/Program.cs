using System;

namespace DayX03TestedConverter
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Converter 3000");
            Console.WriteLine("----------------------");
            bool exit = false;
            while (exit != true)
            {
                Console.WriteLine("Please Choose one of the following choices");
                Console.WriteLine("1. Celcius to Farenheit");
                Console.WriteLine("2. Farenheit to Celcius");
                Console.WriteLine("3. Meters to Yards");
                Console.WriteLine("4. Yards to Meters");
                Console.WriteLine("Enter 0 to Exit");
                int num = int.Parse(Console.ReadLine());
                if (num == 0)
                {
                    exit = true;
                }
                else if (num == 1)
                {
                    Console.WriteLine("Please Enter Temperature in Celcius");
                    double temp = double.Parse(Console.ReadLine());
                    Console.WriteLine(temp + " in Farenheit is " + CelToFaren(temp));
                }
                else if (num == 2)
                {
                    Console.WriteLine("Please Enter Temperature in Farenheit");
                    double temp = double.Parse(Console.ReadLine());
                    Console.WriteLine(temp + " in Celcius is " + FarenToCel(temp));
                }
                else if (num == 3)
                {
                    Console.WriteLine("Please Enter Length in Meters");
                    double leng = double.Parse(Console.ReadLine());
                    Console.WriteLine(leng + " in Yards is " + MetersToYard(leng));
                }
                else if (num == 4)
                {
                    Console.WriteLine("Please Enter Length in Yards");
                    double leng = double.Parse(Console.ReadLine());
                    Console.WriteLine(leng + " in Meters is " + YardToMeters(leng));
                }
                else
                {
                    exit = true;
                }

            }

        }

        public static double CelToFaren(double Cel)
        {
            if (Cel < -273.16)
            {
                throw new ArgumentException("Value is below Obsolute 0");
            }
            return (Cel * 9 / 5) + 32;
        }

        public static double FarenToCel(double Far)
        {
            if (Far < -459.688)
            {
                throw new ArgumentException("Value is below Obsolute 0");
            }
            return (Far - 32) * 5 / 9;
        }

        public static double MetersToYard(double Meter)
        {
            if (Meter < 1)
            {
                throw new ArgumentException("Value is below 1");
            }
            return Meter * 1.094;
        }

        public static double YardToMeters(double Yard)
        {
            if (Yard < 1)
            {
                throw new ArgumentException("Value is below 1");
            }
            return Yard / 1.094;
        }

    }
}

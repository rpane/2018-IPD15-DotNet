using System;

namespace Dayx01Indexer
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimeArray primeNum = new PrimeArray();
            for (int i = 1; i < 10; i++)
                Console.WriteLine(i + " : " + primeNum[i]);

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Dayx01Indexer
{
    class PrimeArray
    {
       /*            
        public bool this[int index]
        {
            get
            {
                return isPrime(index);
            }
        }*/
        
       
        public long this[int index]
        {
            get
            {
                int count = 0;
                int i;
              for(i = 2; count < index; ++i)
                {
                    if (isPrime(i))
                        ++count;
                }

                return i-1;
            }
        }
        


        private bool isPrime(long num)
        {
            if (num == 1) return false;
            if (num == 2) return true;

            if (num % 2 == 0) return false; // Even number     

            for (int i = 2; i < num; i++)
            { // Advance from two to include correct calculation for '4'
                if (num % i == 0) return false;
            }

            return true;
        }

    }
}

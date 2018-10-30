using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz1Many
{
    public class FibNums
    {
        //public List<long> FibNumbers = new List<long>();
        public delegate void FibLoggerDelegateType(int x, long y, string str);
        public FibLoggerDelegateType FibLogger;
        

        public long this[int index]
        {
            get
            {
                
                if(index < 1)
                {
                    throw new ArgumentException("index cannot be less than 1");
                }
                int a = 1;
                int b = 1;
                // In index steps compute Fibonacci sequence iteratively.
                for (int i = 1; i < index; i++)
                {
                    int temp = a;
                    a = b;
                    b = temp + b;
                }
                if(FibLogger != null)
                {
                    FibLogger(index, a, "computed new number");
                }
                return a;
            }
        }

        //you need to compute a new Fibonacci number. In that case first parameter is the N (index), second Fibonacci number returned and other message "computed new number".//
       

        
    }
}

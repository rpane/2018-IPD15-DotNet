using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz1Many
{
    public class LogMsg
    {
        DateTime date;
        int n;
        long fib;
        string msg;

        public LogMsg(DateTime date, int n, long fib, string msg)
        {
            this.Date = date;
            this.N = n;
            this.Fib = fib;
            this.Msg = msg;
        }

        public DateTime Date { get => date; set => date = value; }
        public int N { get => n; set => n = value; }
        public long Fib { get => fib; set => fib = value; }
        public string Msg { get => msg; set => msg = value; }

        public override string ToString()
        {
            return N+" "+Fib+" "+Msg+" "+Date;
        }
    }
}

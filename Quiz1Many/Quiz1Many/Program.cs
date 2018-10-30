using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz1Many
{

    class Program
    {
        public static List<LogMsg> logList = new List<LogMsg>();
        static void Main(string[] args)
        {
            FibNums fibNumbers = new FibNums();
            for(int i = 1; i < 10; i++)
            {
                Console.WriteLine(i + " : " + fibNumbers[i]);
            }

                      
            //displayMessage(n, fib, msg);
            //saveMessage(n,fib,msg);
            //readLogsFromFile();
            //fibValBelow10OrderdbyDate();
            //FibsOrderdbySeconds();

            Console.ReadKey();
        }
        static void displayMessage(int n, long fib, string msg)
        {
            Console.WriteLine(n + " " + fib + " " + msg);
        }
        static void saveMessage(int n, long fib, string msg)
        {
            string ts = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            File.AppendAllText("records.txt", n + ";" + fib + ";"+ msg+";"+ts+"\n");
        }
        static void readLogsFromFile()
        {
            try
            {
                string[] lineArray = File.ReadAllLines(@"..\..\records.txt");
                foreach(string line in lineArray)
                {
                    string[] split = line.Split(';');
                    LogMsg lm = new LogMsg(DateTime.Parse(split[3]),int.Parse(split[0]),long.Parse(split[1]),split[2]);
                    logList.Add(lm);
                }

            }
            catch (IOException ex)
            {
                Console.WriteLine(ex);
            }
        }
        public static void fibValBelow10OrderdbyDate()
        {
            List<LogMsg> sorted = logList.OrderBy(LogMsg => LogMsg.Date).ThenBy(LogMsg => LogMsg.Fib < 10).ToList();
            foreach(LogMsg x in sorted)
            {
                Console.WriteLine(x);
            }
        }

        public static void FibsOrderdbySeconds()
        {
            List<LogMsg> sorted = logList.OrderBy(LogMsg => LogMsg.Date.Second).ToList();
            foreach (LogMsg x in sorted)
            {
                Console.WriteLine(x);
            }
        }
    }
}

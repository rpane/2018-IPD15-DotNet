using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02BankingRecords
{
    class Program
    {
        static List<AccountTransaction> transactionList = new List<AccountTransaction>();
        static void Main(string[] args)
        {
            try
            {
                string[] lines = File.ReadAllLines(@"..\..\operations.txt");
                foreach (string line in lines)
                {
                    try
                    {
                        AccountTransaction a = new AccountTransaction(line);
                        transactionList.Add(a);
                        Console.WriteLine(a.ToString());
                    }
                    catch (InvalidDataException ex)
                    {
                        Console.WriteLine(ex);
                    }

                }
                decimal bal = Total(transactionList);
                Console.WriteLine("Your final balance is $" + bal);
                Console.ReadKey();
            }catch (IOException ex)
            {
                Console.WriteLine(ex);
            }
        }
        
        public static decimal Total(List<AccountTransaction> trans)
        {
            
            decimal withdrawl =0;
            decimal deposit = 0;
            foreach(var v in trans)
            {
                withdrawl += v.Withdrawal;
                deposit += v.Deposit;
            }
            return deposit - withdrawl;
            
        }
    }
}

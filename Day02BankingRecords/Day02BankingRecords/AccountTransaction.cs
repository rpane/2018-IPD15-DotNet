using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02BankingRecords
{
    class AccountTransaction
    {
        DateTime date;
        string description;
        decimal deposit;
        decimal withdrawal;

        public AccountTransaction(string line)
        {
          
        }
        public DateTime date { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

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
            string[] words = line.Split(';');
            string pattern = @"[0-9]{4}-[0-1][1-9]-[0-3][0-9]";
            Match m = Regex.Match(words[0], pattern);
            if(m.Success == false)
            {
                throw new InvalidDataException("Invalid Date");
            }
            date = Convert.ToDateTime(words[0]);
            
            if (words[1].Length < 2)
            {
                throw new InvalidDataException("Length of Description is too short");
            }
            description = words[1];
            
            if(int.Parse(words[2]) <0 || int.Parse(words[3]) < 0)
            {
                throw new InvalidDataException("Number is below 0");
            }
            deposit = decimal.Parse(words[2]);
            withdrawal = decimal.Parse(words[3]);

            if (int.Parse(words[2]) >0 && int.Parse(words[3]) > 0)
            {
                throw new InvalidDataException("Cannot compute two operations at once");
            }
        }
        public DateTime Date
        {
            get
            {
                return date;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
        }

        public decimal Deposit
        {
            get
            {
                return deposit;
            }
        }
        public decimal Withdrawal
        {
            get
            {
                return withdrawal;
            }
        }

        public override string ToString()
        {
            if(withdrawal == 0)
            {
                return string.Format("{0:yyyy-MM-dd} {1} of ${2}", date, description, deposit);
            }
            else
            {
                return string.Format("{0:yyyy-MM-dd} {1} for -${2}", date, description, withdrawal);
            }
            
        }
    }
}

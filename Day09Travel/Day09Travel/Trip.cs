using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day09Travel
{
    public class Trip
    {
        int id;
        string destination;
        string name;
        string passportNo;
        DateTime departure;
        DateTime returnDate;

        public Trip(string destination, string name, string passportNo, DateTime departure, DateTime returnDate, TransportEnum transport)
        {
            
            Destination = destination;
            Name = name;
            PassportNo = passportNo;
            Departure = departure;
            ReturnDate = returnDate;
            Transport = transport;
        }

        public string Destination { get => destination; set => destination = value; }
        public string Name { get => name; set => name = value; }
        public string PassportNo { get => passportNo; set => passportNo = value; }
        public DateTime Departure { get => departure; set => departure = value; }
        public DateTime ReturnDate { get => returnDate; set => returnDate = value; }
        public TransportEnum Transport { get; set; }
        public int Id { get => id; set => id = value; }

        public enum TransportEnum { Fly, Drive, Bus, Train, Other};

        public override string ToString()
        {
            return string.Format("{0}, {1} to {2} on {3}", Name, PassportNo, Destination, Departure.ToString("MMM dd, yyyy"));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05TravelGrid
{
    class Trip
    {
        string destination;
        string travellerName;
        string travellerPassport;
        DateTime departureDate;
        DateTime returnDate;

        public Trip(string destination, string travellerName, string travellerPassport, DateTime departureDate, DateTime returnDate)
        {
            this.destination = destination;
            this.travellerName = travellerName;
            this.travellerPassport = travellerPassport;
            this.departureDate = departureDate;
            this.returnDate = returnDate;
        }

        public string Destination { get => destination; set => destination = value; }
        public string TravellerName { get => travellerName; set => travellerName = value; }
        public string TravellerPassport { get => travellerPassport; set => travellerPassport = value; }
        public DateTime DepartureDate { get => departureDate; set => departureDate = value; }
        public DateTime ReturnDate { get => returnDate; set => returnDate = value; }

        public override string ToString()
        {
            return string.Format("{0},({1}) to {2} on {3: MMM d, yyyy}",travellerName, travellerPassport,Destination,DepartureDate);
        }
    }

}

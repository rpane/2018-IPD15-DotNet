using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz02Airports
{
    class Airport
    {
        private static int count;
        long id;
        string code, city;
        double lat, log;
        int elevation;

        public Airport(string code, string city, double lat, double log, int elevation)
        {
            
            Code = code;
            City = city;
            Lat = lat;
            Log = log;
            Elevation = elevation;
            id = ++count;
        }
        public long Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                checkCodeValid(value);
                code = value;
            }
        }
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                checkCityValid(value);
                city = value;
            }
        }
        public double Lat
        {
            get
            {
                return lat;
            }
            set
            {
                lat = value;
            }
        }
        public double Log
        {
            get
            {
                return log;
            }
            set
            {
                log = value;
            }
        }
        public int Elevation
        {
            get
            {
                return elevation;
            }
            set
            {
                elevation = value;
            }
        }

        public static void checkCityValid(string city)
        {
            if(city.Length<2 ||city.Length > 50)
            {
                throw new ArgumentOutOfRangeException("City must be between 2-50 characters");
            }
        }
        public static void checkCodeValid(string code)
        {
            if ( code.Length >3  || code.Length < 3)
            {
                throw new ArgumentOutOfRangeException("Code must be 3 characters long");
            }
            bool isUpper = false;
            for(int i = 0; i < code.Length; i++)
            {
                if (Char.IsUpper(code[i]))
                {
                    isUpper = true;
                }
            }
            if(isUpper == false)
            {
                throw new ArgumentOutOfRangeException("Code must be UpperCase");
            }
        }

        public override string ToString()
        {
            return id+","+code+","+city+","+lat+","+log+","+elevation;
        }
    }
}

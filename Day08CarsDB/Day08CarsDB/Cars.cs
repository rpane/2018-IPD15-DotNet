using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08CarsDB
{
   public class Cars
    {
        int id;
        string makeModel;
        double engineSize;
        string fuelType;

        public Cars(string makeModel, double engineSize, string fuelType)
        {
            this.MakeModel = makeModel;
            this.EngineSize = engineSize;
            this.FuelType = fuelType;
        }

        public int Id { get => id; set => id = value; }
        public string MakeModel { get => makeModel; set => makeModel = value; }
        public double EngineSize { get => engineSize; set => engineSize = value; }
        public string FuelType { get => fuelType; set => fuelType = value; }

        public override string ToString()
        {
            return Id+":"+MakeModel+","+EngineSize+","+FuelType;
        }
    }
}

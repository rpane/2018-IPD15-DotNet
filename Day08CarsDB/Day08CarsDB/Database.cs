using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08CarsDB
{
    class Database
    {
        //Home
        const string CONN_STRING = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\OneDrive - John Abbott College\\C#\\Database for C#\\FirstDB.mdf\";Integrated Security=True;Connect Timeout=30;MultipleActiveResultSets=true";
        //School
        //const string CONN_STRING = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\0639300\\OneDrive - John Abbott College\\C#\\Database for C#\\FirstDB.mdf\";Integrated Security=True;Connect Timeout=30";

        SqlConnection conn;

        public Database()
        {
            // FIXME: Handle System.ArgumentException when conn_string is invalid
            conn = new SqlConnection(CONN_STRING);
            conn.Open();
        }

        public List<Cars> GetAllCars()
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM Cars", conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Cars> result = new List<Cars>();
                    while (reader.Read())
                    {
                        int id = (int)reader["Id"];
                        string makeModel = (string)reader["makeModel"];
                        double engineSize = (double)reader["engineSize"];
                        string fuelType = (string)reader["fuelType"];
                        Cars p = new Cars(makeModel,engineSize,fuelType);
                        p.Id = id;
                        result.Add(p);
                    }
                    return result;
                }
            }
        }
        public void AddCar(Cars c)
        {
            using (SqlCommand insertCommand = new SqlCommand(
                "INSERT INTO Cars (makeModel, engineSize,fuelType) VALUES (@makeModel, @engineSize, @fuelType) ", conn))
            {
                insertCommand.Parameters.AddWithValue("@makeModel", c.MakeModel);
                insertCommand.Parameters.AddWithValue("@engineSize", c.EngineSize);
                insertCommand.Parameters.AddWithValue("@fuelType", c.FuelType);
                insertCommand.ExecuteNonQuery();
            }
        }

        public void UpdateCar(Cars c)
        {
            using (SqlCommand updateCommand = new SqlCommand(
                "UPDATE Cars SET makeModel=@makeModel, engineSize=@engineSize, fuelType=@fuelType WHERE Id=@Id", conn))
            {
                updateCommand.Parameters.AddWithValue("@Id", c.Id);
                updateCommand.Parameters.AddWithValue("@makeModel", c.MakeModel);
                updateCommand.Parameters.AddWithValue("@engineSize", c.EngineSize);
                updateCommand.Parameters.AddWithValue("@fuelType", c.FuelType);
                updateCommand.ExecuteNonQuery();
            }
        }

        public void DeleteCar(int id)
        {
            using (SqlCommand updateCommand = new SqlCommand(
                "DELETE FROM Cars WHERE Id=@Id", conn))
            {
                updateCommand.Parameters.AddWithValue("@Id", id);
                updateCommand.ExecuteNonQuery();
            }
        }
    }
}

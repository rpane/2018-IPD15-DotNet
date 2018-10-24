using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day09Travel
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
        public List<Trip> GetAllTrips()
        {

            using (SqlCommand command = new SqlCommand("SELECT * FROM Trips", conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Trip> result = new List<Trip>();
                    while (reader.Read())
                    {
                        int id = (int)reader["Id"];
                        string destination = (string)reader["Destination"];
                        string name = (string)reader["Name"];
                        string passport = (string)reader["PassportNo"];
                        DateTime depDate =(DateTime)reader["Departure"];
                        DateTime retDate = (DateTime)reader["ReturnDate"];
                        string transportStr = (string)reader["TransportMethod"];
                        Trip.TransportEnum transport;
                        if (!Enum.TryParse<Trip.TransportEnum>(transportStr, out transport))
                        {
                            throw new InvalidCastException("Enum value invalid: " + transportStr);
                        }
                        Trip p = new Trip(destination,name,passport,depDate,retDate,transport) ;
                        p.Id = id;
                        result.Add(p);
                    }
                    return result;
                }
            }
        }

        public void AddPerson(Trip t)
        {
            using (SqlCommand insertCommand = new SqlCommand(
                "INSERT INTO Trips (Destination, Name, PassportNo , Departure, ReturnDate, TransportMethod) VALUES" +
                " (@Destination, @Name, @PassportNo, @Departure, @ReturnDate, @TransportMethod) ", conn))
            {
                insertCommand.Parameters.AddWithValue("@Destination", t.Destination);
                insertCommand.Parameters.AddWithValue("@Name", t.Name);
                insertCommand.Parameters.AddWithValue("@PassportNo", t.PassportNo);
                insertCommand.Parameters.AddWithValue("@Departure", t.Departure.ToString("yyyy-MM-dd"));
                insertCommand.Parameters.AddWithValue("@ReturnDate", t.ReturnDate.ToString("yyyy-MM-dd"));
                insertCommand.Parameters.AddWithValue("@TransportMethod", t.Transport.ToString());
                insertCommand.ExecuteNonQuery();
            }
        }
    }
}

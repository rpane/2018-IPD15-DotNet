using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07FirstDB
{
    class Program
    {
        //Home
        const string CONN_STRING = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\OneDrive - John Abbott College\\C#\\Database for C#\\FirstDB.mdf\";Integrated Security=True;Connect Timeout=30";
        //School
        //const string CONN_STRING = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\0639300\\OneDrive - John Abbott College\\C#\\Database for C#\\FirstDB.mdf\";Integrated Security=True;Connect Timeout=30";
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection(CONN_STRING);
            conn.Open();
            using (SqlCommand insertCommand = new SqlCommand("INSERT INTO People (Name, Age) VALUES(@Name, @Age)", conn))
            {
                insertCommand.Parameters.AddWithValue("@Name", "Jimmy");
                insertCommand.Parameters.AddWithValue("@Age", 33);
                //insertCommand.ExecuteNonQuery();
            }

            //Task execute SELECT * FROM People and display every row in seperate line
            //1 : Jerry is 33
            using (SqlCommand selectAll = new SqlCommand("SELECT * FROM People", conn))
            {
                using (SqlDataReader reader = selectAll.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["Id"];
                        string name = (string)reader["Name"];
                        int age = (int)reader["Age"];
                        Console.WriteLine("{0} : {1} is {2} y/o", id, name, age);
                    }
                }
                Console.ReadKey();
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08PeopleAgain
{
    public class Database
    {
        //Home
        //const string CONN_STRING = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\OneDrive - John Abbott College\\C#\\Database for C#\\FirstDB.mdf\";Integrated Security=True;Connect Timeout=30;MultipleActiveResultSets=true";
        //School
        const string CONN_STRING = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\0639300\\OneDrive - John Abbott College\\C#\\Database for C#\\FirstDB.mdf\";Integrated Security=True;Connect Timeout=30";

        SqlConnection conn;

        public Database()
        {
            // FIXME: Handle System.ArgumentException when conn_string is invalid
            conn = new SqlConnection(CONN_STRING);
            conn.Open();
        }

        
        public List<Person> GetAllPeople()
        {

            using (SqlCommand command = new SqlCommand("SELECT * FROM People", conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Person> result = new List<Person>();
                    while (reader.Read())
                    {
                        int id = (int)reader["Id"];
                        string name = (string)reader["Name"];
                        int age = (int)reader["Age"];
                        string genderStr = (string)reader["Gender"];
                        Person.GenderEnum gender;
                        if(!Enum.TryParse<Person.GenderEnum>( genderStr, out gender))
                        {
                            throw new InvalidCastException("Enum value invalid: " +genderStr);
                        }
                        Person p = new Person() { Id = id, Name = name, Age = age, Gender = gender };
                        result.Add(p);
                    }
                    return result;
                }
            }
        }

        public int AddPerson(Person p)
        {
            using (SqlCommand insertCommand = new SqlCommand(
                "INSERT INTO People (Name, Age , Gender) OUTPUT Inserted.ID VALUES (@Name, @Age, @Gender) ", conn))
            {
                insertCommand.Parameters.AddWithValue("@Name", p.Name);
                insertCommand.Parameters.AddWithValue("@Age", p.Age);
                insertCommand.Parameters.AddWithValue("@Gender", p.Gender.ToString());
                int Id = (int)insertCommand.ExecuteScalar();
                p.Id = Id;
                Console.WriteLine("Insert ID=" + Id);
                return Id;
            }
        }

        public void UpdatePerson(Person p)
        {
            using (SqlCommand updateCommand = new SqlCommand(
                "UPDATE People SET Name=@Name, Age=@Age, Gender=@Gender WHERE Id=@Id", conn))
            {
                updateCommand.Parameters.AddWithValue("@Id", p.Id);
                updateCommand.Parameters.AddWithValue("@Name", p.Name);
                updateCommand.Parameters.AddWithValue("@Age", p.Age);
                updateCommand.Parameters.AddWithValue("@Gender", p.Gender.ToString());
                updateCommand.ExecuteNonQuery();
            }
        }

        public void DeletePerson(int id)
        {
            using (SqlCommand updateCommand = new SqlCommand(
                "DELETE FROM People WHERE Id=@Id", conn))
            {
                updateCommand.Parameters.AddWithValue("@Id", id);
                updateCommand.ExecuteNonQuery();
            }
        }
    }
}

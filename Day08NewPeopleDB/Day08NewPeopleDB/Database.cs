using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08NewPeopleDB
{
    class Database
    {
        const string CONN_STRING = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\OneDrive - John Abbott College\\C#\\Database for C#\\FirstDB.mdf\";Integrated Security=True;Connect Timeout=30;MultipleActiveResultSets=true";
        SqlConnection conn = new SqlConnection(CONN_STRING);
        
        public Database()
        {
            conn.Open();
        }

        public List<Person> GetAllPeople()
        {
            List<Person> people = new List<Person>();        
                
                using(SqlCommand selectAll = new SqlCommand("SELECT * FROM NewPeople",conn))
                {
                    
                    using (SqlDataReader reader = selectAll.ExecuteReader())
                    {
                        
                        while (reader.Read())
                        {
                            int id = (int)reader["Id"];
                            string name = (string)reader["Name"];
                            int age = (int)reader["Age"];
                            double height = (double)reader["Height"];
                            Person a = new Person(name, age, height);
                            a.Id = id;
                        people.Add(a);
                        }
                        
                       
                    }

                }
                return people;

            
           
        }

        public void AddPerson (Person p)
        {
            
            using (SqlCommand insertCommand = new SqlCommand("INSERT INTO NewPeople (Name, Age, Height) VALUES(@Name, @Age, @Height)", conn))
            {
               
                insertCommand.Parameters.AddWithValue("@Name", p.Name);
                insertCommand.Parameters.AddWithValue("@Age", p.Age);
                insertCommand.Parameters.AddWithValue("@Height", p.Height);
                insertCommand.ExecuteNonQuery();
            }
        }

        public void DeletePerson(int id)
        {

            using(SqlCommand deleteID = new SqlCommand("DELETE FROM NewPeople WHERE Id = @Id", conn))
            {
                
                deleteID.Parameters.AddWithValue("@Id", id);
                deleteID.ExecuteNonQuery();
            }
        }

        public void UpdatePerson(Person P)
        {
            using (SqlCommand updatePerson = new SqlCommand("UPDATE NewPeople SET Name = @Name, Age = @Age, Height = @Height", conn))
            {
                
                updatePerson.Parameters.AddWithValue("@Name", P.Name);
                updatePerson.Parameters.AddWithValue("@Age", P.Age);
                updatePerson.Parameters.AddWithValue("@Height", P.Height);
            }
        }
    }
}

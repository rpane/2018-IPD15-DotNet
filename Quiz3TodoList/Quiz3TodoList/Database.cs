using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz3TodoList
{
    class Database
    {
        
        const string CONN_STRING = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\0639300\\OneDrive - John Abbott College\\C#\\Database for C#\\FirstDB.mdf\";Integrated Security=True;Connect Timeout=30";

        SqlConnection conn;

        public Database()
        {            
            conn = new SqlConnection(CONN_STRING);
            conn.Open();
        }

        public List<Todo> GetAllTasks()
        {

            using (SqlCommand command = new SqlCommand("SELECT * FROM Todo", conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Todo> result = new List<Todo>();
                    while (reader.Read())
                    {
                        int id = (int)reader["Id"];
                        string task = (string)reader["Task"]; 
                        DateTime dueDate = (DateTime)reader["DueDate"];
                        string taskStr = (string)reader["TaskStatus"];
                        Todo.TaskStatus status;
                        if (!Enum.TryParse<Todo.TaskStatus>(taskStr, out status))
                        {
                            throw new InvalidCastException("Enum value invalid: " + taskStr);
                        }
                        Todo p = new Todo(task, dueDate, status);
                        p.Id = id;
                        result.Add(p);
                    }
                    return result;
                }
            }
        }
        public void AddTodo(Todo t)
        {
            using (SqlCommand insertCommand = new SqlCommand(
                "INSERT INTO Todo (Task, DueDate, TaskStatus) VALUES" +
                " (@Task, @DueDate, @TaskStatus) ", conn))
            {
                insertCommand.Parameters.AddWithValue("@Task", t.Task);
                insertCommand.Parameters.AddWithValue("@DueDate", t.DueDate.ToString("yyyy-MM-dd")); 
                insertCommand.Parameters.AddWithValue("@TaskStatus", t.taskStatus.ToString());
                insertCommand.ExecuteNonQuery();
            }
        }
        public void UpdateTodo(Todo t)
        {
            using (SqlCommand updateCommand = new SqlCommand(
                "UPDATE Todo SET Task=@Task, DueDate=@DueDate, TaskStatus=@TaskStatus WHERE Id=@Id", conn))
            {
                updateCommand.Parameters.AddWithValue("@Id", t.Id);
                updateCommand.Parameters.AddWithValue("@Task", t.Task);
                updateCommand.Parameters.AddWithValue("@DueDate", t.DueDate.ToString("yyyy-MM-dd"));
                updateCommand.Parameters.AddWithValue("@TaskStatus", t.taskStatus.ToString());
                updateCommand.ExecuteNonQuery();
            }
        }
        public void DeleteTodo(int id)
        {
            using (SqlCommand updateCommand = new SqlCommand(
                "DELETE FROM Todo WHERE Id=@Id", conn))
            {
                updateCommand.Parameters.AddWithValue("@Id", id);
                updateCommand.ExecuteNonQuery();
            }
        }
    }
}

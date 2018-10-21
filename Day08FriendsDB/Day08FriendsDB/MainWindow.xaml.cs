using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Day08FriendsDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Home
        const string CONN_STRING = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\OneDrive - John Abbott College\\C#\\Database for C#\\FirstDB.mdf\";Integrated Security=True;Connect Timeout=30";
        //School
        //const string CONN_STRING = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\0639300\\OneDrive - John Abbott College\\C#\\Database for C#\\FirstDB.mdf\";Integrated Security=True;Connect Timeout=30";
       
       SqlConnection conn = new SqlConnection(CONN_STRING);
        public MainWindow()
        {
            InitializeComponent(); 
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {            
            conn.Open();
            using (SqlCommand insertCommand = new SqlCommand("INSERT INTO Friends (Name) VALUES(@Name)", conn))
            {
                insertCommand.Parameters.AddWithValue("@Name", tbName.Text);                
                insertCommand.ExecuteNonQuery();               
            }
            using (SqlCommand selectAll = new SqlCommand("SELECT TOP 1 * FROM Friends ORDER BY ID DESC", conn))
            {
                using (SqlDataReader reader = selectAll.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = (string)reader["Name"];
                        lbFriends.Items.Add(name);
                        
                    }
                }
               
            }
            tbName.Text = "";
            conn.Close();

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            
            conn.Open();
            using (SqlCommand deleteCommand = new SqlCommand("TRUNCATE TABLE Friends", conn))
            {
                deleteCommand.ExecuteNonQuery();
            }
            lbFriends.Items.Clear();
            
            conn.Close();
        }
    }
}

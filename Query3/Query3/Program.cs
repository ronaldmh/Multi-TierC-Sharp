using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Query3
{
    public class Connection
    {
        private static string savedString = null;
        
        // Function to do connection
        public static string GetConnectionString()
        {
            if(savedString == null) {

                SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
                cs.DataSource = "(local)";
                cs.InitialCatalog = "EMP";
                cs.UserID = "sa";
                cs.Password = "sysadm";
                savedString = cs.ConnectionString;
            }

            return savedString;
        }
        
        

    }
    class Program
    {
       
        static void Main(string[] args)
        {
            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Connection.GetConnectionString();            
            
            con.Open();

            //Create a command
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM COMPANY"; // Query instruction
            SqlDataReader reader = cmd.ExecuteReader(); // Intruction that create a object named in this case reader

            // That goes in one direction, starting on top until the end
            while (reader.Read())
            {
                Console.WriteLine("id = {0}; Name = {1}", reader.GetInt32(0), reader.GetString(1)); // {} parameters to be replace for the values - Format
                Console.WriteLine("Age = {0}", reader.GetInt32(2));
                Console.WriteLine("Address = " + reader.GetString(3));
                Console.WriteLine("Salary = {0:F2}", reader.GetFloat(4));
                Console.WriteLine("Salary = {0}", reader.GetFloat(4).ToString("F2"));
                Console.WriteLine("Salary = {0}", reader.GetFloat(4).ToString("N2"));
            }

            con.Close();
            Console.ReadKey();

        }
    }
}

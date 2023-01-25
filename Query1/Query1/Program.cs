using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Query1
{
    class Program
    {
        static void Main(string[] args)
        {

            // 1 step - Connection to database - create a constructor
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            cs.DataSource = "(local)";
            cs.InitialCatalog = "EMP";
            cs.UserID = "sa";
            cs.Password = "sysadm";

            // 2- Step - Injection by a setter creating and open the Connection 

            SqlConnection con = new SqlConnection();
            con.ConnectionString = cs.ConnectionString;
            // Open the connection
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

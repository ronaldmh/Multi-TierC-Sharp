using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CreateDB
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            cs.DataSource = "(local)";
            cs.UserID = "sa";
            cs.Password= "sysadm";
            Console.WriteLine(cs.ConnectionString);
            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = cs.ConnectionString; // Setter

            con.Open();
            SqlCommand cmd = con.CreateCommand();            
            cmd.CommandText = "CREATE DATABASE EMP"; // Command to execute and create a database                      

            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Database created");
            }
            catch(Exception e){
                Console.WriteLine("Database not created");
                Console.WriteLine(e.Message);
            }
            
            con.Close();
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CreateTables
{
    class Program
    {
        static void Main(string[] args)
        {       
            //Connection to database
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            cs.DataSource = "(local)";
            cs.InitialCatalog = "EMP";
            cs.UserID = "sa";
            cs.Password= "sysadm";

            // Injection by a setter
            SqlConnection con = new SqlConnection();
            con.ConnectionString = cs.ConnectionString;
            
            con.Open(); // Open the connection

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "CREATE TABLE COMPANY" +
                "(ID INT PRIMARY KEY NOT NULL," +
                "NAME       TEXT    NOT NULL," +
                "AGE        INT     NOT NULL," +
                "ADDRESS    CHAR(50)," +
                "SALARY     REAL)";

            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table created");
            }
            catch (Exception e)
            {
                Console.WriteLine("Table not created");
                Console.WriteLine(e.Message);
            }

            con.Close();
         
            Console.ReadKey();
            
            
        }
    }
}

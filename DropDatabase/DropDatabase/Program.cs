using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DropDatabase
{
    class Program
    {
        static void Main(string[] args)
        {

            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            cs.DataSource = "(local)";
            //cs.InitialCatalog = "master"; // 
            cs.UserID = "sa";
            cs.Password = "sysadm";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = cs.ConnectionString; // Setter

            con.Open();

            SqlCommand cmd = con.CreateCommand();

            cmd.CommandText = "ALTER DATABASE EMP SET SINGLE_USER WITH ROLLBACK IMMEDIATE;" + "DROP DATABASE EMP";
            
            //cmd.CommandText = "DROP DATABASE EMP";

            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Database successfuly deleted");
            }
            catch (Exception e)
            {
                Console.WriteLine("Tabla not deleted");
                Console.WriteLine(e.ToString());
            }

            con.Close();
            Console.ReadKey();
            
        }
    }
}

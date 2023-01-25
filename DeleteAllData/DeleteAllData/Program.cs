using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DeleteAllData
{
    class Program
    {
        static void Main(string[] args)
        {

            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            cs.DataSource = "(local)";
            cs.InitialCatalog = "EMP";
            cs.UserID = "sa";
            cs.Password = "sysadm";
            Console.WriteLine(cs.ConnectionString);

            SqlConnection con = new SqlConnection();
            con.ConnectionString = cs.ConnectionString; // Setter

            con.Open();
            SqlCommand cmd = con.CreateCommand();

            try
            {
                cmd.CommandText = "DELETE from COMPANY"; // Command to execute and create a database 
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data successfully deleted");
                Console.WriteLine();

            }
            catch (Exception e)
            {
                Console.WriteLine("Data not deleted");
                
            }

            con.Close();
            Console.ReadKey();

        }
    }
}

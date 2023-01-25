using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace DropTable
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
                cmd.CommandText = "DROP TABLE COMPANY"; // Command to drop table 
                cmd.ExecuteNonQuery();                
                Console.WriteLine("Tables successfuly dletedData successfully deleted");
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

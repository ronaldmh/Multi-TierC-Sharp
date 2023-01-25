using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StoreData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Connection to database
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            cs.DataSource = "(local)";
            cs.InitialCatalog = "EMP";
            cs.UserID = "sa";
            cs.Password = "sysadm";

            // Injection by a setter
            SqlConnection con = new SqlConnection();
            con.ConnectionString = cs.ConnectionString;

            con.Open(); // Open the connection

            SqlCommand cmd = con.CreateCommand();


            // command to fill table
            try
            {
            cmd.Transaction= con.BeginTransaction();

                cmd.CommandText = "INSERT INTO COMPANY (ID,NAME,AGE,ADDRESS,SALARY)" +
                "VALUES (2,'Allen',25,'Texas', 15000.00)";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "INSERT INTO COMPANY (ID,NAME,AGE,ADDRESS,SALARY)" +
               "VALUES (1,'Paul',32,'California', 2000)";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "INSERT INTO COMPANY (ID,NAME,AGE,ADDRESS,SALARY)" +
                "VALUES (3,'Teddy',23,'Norway', 2000)";

                cmd.CommandText = "INSERT INTO COMPANY (ID,NAME,AGE,ADDRESS,SALARY)" +
                "VALUES (4,'Mark',25,'Richmond', 6500.00)";

                cmd.ExecuteNonQuery();
                
                cmd.Transaction.Commit();
                Console.WriteLine("Data successfully inserted");

            }
            catch (SqlException e)
            {
                Console.WriteLine("Data not inserted");
                Console.WriteLine(e.ErrorCode);
                Console.WriteLine(e.Message);


            }

            con.Close();
            Console.ReadKey();

        }
    }
}

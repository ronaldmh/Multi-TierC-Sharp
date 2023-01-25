﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Update
{    

    class Program
    {
        static void Main(string[] args)
        {

            bool updated = false;
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            cs.DataSource = "(local)";
            cs.InitialCatalog = "EMP";
            cs.UserID = "sa";
            cs.Password = "sysadm"; SqlConnection con = new SqlConnection();
            con.ConnectionString = cs.ConnectionString; con.Open(); SqlCommand cmd = con.CreateCommand();
            try
            {
                cmd.Transaction = con.BeginTransaction();
                cmd.CommandText = "UPDATE COMPANY set SALARY = 25000.00 where ID=1";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "DELETE from COMPANY where ID=2";
                cmd.ExecuteNonQuery();
                cmd.Transaction.Commit();
                updated = true;
                Console.WriteLine("Data successfully updated");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Data not updated");
            }
            if (updated)
            {
                cmd.CommandText = "SELECT * FROM COMPANY";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("Id = {0}; Name = {1}", reader.GetInt32(0), reader.GetString(1));
                    Console.WriteLine("Age = {0}", reader.GetInt32(2));
                    Console.WriteLine("Address = {0}", reader.GetString(3));
                    //Console.WriteLine("Salary = {0:F2}", reader.GetFloat(4));
                    //Console.WriteLine("Salary = {0}", reader.GetFloat(4).ToString("F2"));
                    Console.WriteLine("Salary = {0}", reader.GetFloat(4).ToString("N2"));
                    Console.WriteLine();
                }
            }
            con.Close();
            Console.ReadKey();

        }
    }
}

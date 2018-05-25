using NUnit.Framework;
using System.Xml;
using System.IO;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CodeTest
{
    class ReadFromSQL
    {
        public SqlConnection conn;
        public ReadFromSQL(SqlConnection conn)
        {
            this.conn = conn;
        }

        public void getValue(string sqlString)
        {
            Console.WriteLine("Enter username : ");
            string username = Console.ReadLine();
            using (SqlConnection connection = new SqlConnection(sqlString))
            using (SqlCommand command = new SqlCommand("select * from loginEBS", connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                   while (reader.Read())
                    {
                        if (reader["email"].ToString() == username)
                        {
                            Console.WriteLine("Correct username");
                        }
                        else
                        {
                            Console.WriteLine("wrong username");
                        }
                        //Console.WriteLine("email : "+reader["email"].ToString());
                        //Console.WriteLine("password : " + reader["password"].ToString());
                        //Console.WriteLine();
                    }
                }
            }
        }

    }
}

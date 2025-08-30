using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //creating connection 
            SqlConnection connection = new SqlConnection("Data Source=AMANPODDAR\\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=True;Connect Timeout=30;");

            //creating command table 

            SqlCommand command=new SqlCommand("Select * FROM [dbo].[Employee]", connection);

            //opening connection
            connection.Open();

            //reading data
            SqlDataReader reader=command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader["FirstName"]+" " + reader["LastName"]);
            }

        }
    }
}

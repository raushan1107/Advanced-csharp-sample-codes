using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBadoLearning
{
    public class AdoNetEmployeeDemo
    {
        private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=EDB;Integrated Security=True;";

        public static void Run()
        {
            Console.WriteLine("--- ADO.NET Employee Demo ---");

            // SQL query with a JOIN and a parameter
            string queryString = "SELECT Name, Salary, Department FROM Employees;";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        // Manually reading data from the reader by column name/index
                        string name = reader["Name"].ToString();
                        decimal salary = (decimal)reader["Salary"];
                        string department = reader["Department"].ToString();

                        Console.WriteLine("{0} {1} {2}", name, salary, department);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            Console.WriteLine("--- ADO.NET Employee Demo End ---");
        }
    }
}

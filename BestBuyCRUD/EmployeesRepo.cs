using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace BestBuyCRUD
{
    class EmployeesRepo
    {
        private string connectionString; // field

        public EmployeesRepo(string conn)
        {
            connectionString = conn;
        }

        public List<Employees> GetEmployees()
        {
            MySqlConnection connect = new MySqlConnection(connectionString);

            using (connect)
            {
                connect.Open();

                MySqlCommand cmd = connect.CreateCommand();
                cmd.CommandText = "Select EmployeeId AS id, FirstName AS First, MiddleInitial AS middle, LastName AS Last," +
                    "EmailAddress AS Email, PhoneNumber As Number, Title, DateOfBirth AS Bday";

                MySqlDataReader reader = cmd.ExecuteReader();

                List<Employees> employees = new Employees();

                
            }


        }
    }
}

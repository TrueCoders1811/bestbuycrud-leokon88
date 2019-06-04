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
                cmd.CommandText = "Select EmployeeId AS ID, FirstName AS First, MiddleInitial AS Middle, LastName AS Last," +
                    "EmailAddress AS Email, PhoneNumber As Number, Title, DateOfBirth AS Bday";

                MySqlDataReader reader = cmd.ExecuteReader();

                List<Employees> employees = new List<Employees>();
                while(reader.Read())
                {
                    Employees emp = new Employees();
                    emp.EmployeeId = (int)reader["ID"];
                    emp.FirstName = reader["First"].ToString();
                    emp.MiddleInitial = reader["Middle"].ToString();
                    emp.LastName = reader["Last"].ToString();
                    emp.EmailAddress = reader["Email"].ToString();
                    emp.PhoneNumber = reader["Number"].ToString();
                    emp.Title = reader["Title"].ToString();
                    emp.DateOfBirth = Convert.ToDateTime(reader["Bday"]);
                    employees.Add(emp);
                }
                return employees;
                
            }
         }

        public void CreateEmployees(Employees createEmployees)
        {
            MySqlConnection connect= new MySqlConnection(connectionString);

            using (connect)
            {
                connect.Open();
                MySqlCommand cmd = connect.CreateCommand();
                cmd.CommandText = "INSERT INTO employees (EmployeeId,FirstName, MiddleInitial," +
                    "LastName, EmailAddress, PhoneNumber, Title, DateOfBirth) VALUE" +
                    "(@ID, @First, @Middle, @Last, @Email, @Number,@Title,@Bday)";
                cmd.Parameters.AddWithValue("ID", createEmployees.EmployeeId);
                cmd.Parameters.AddWithValue("First", createEmployees.FirstName);
                cmd.Parameters.AddWithValue("Middle", createEmployees.MiddleInitial);
                cmd.Parameters.AddWithValue("Last", createEmployees.LastName);
                cmd.Parameters.AddWithValue("Email", createEmployees.EmailAddress);
                cmd.Parameters.AddWithValue("Number", createEmployees.PhoneNumber);

                cmd.ExecuteNonQuery();
            }
        }


    }
}

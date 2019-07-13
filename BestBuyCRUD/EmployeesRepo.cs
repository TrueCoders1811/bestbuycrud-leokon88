using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace BestBuyCRUD
{
    class EmployeesRepo
    {
        public string connectionString;

        public EmployeesRepo(string conn)
        {
            connectionString = conn;
        }

        public List<Employee> GetEmployees()
        {
            MySqlConnection connect = new MySqlConnection(connectionString);

            using (connect)
            {
                connect.Open();

                MySqlCommand cmd = connect.CreateCommand();
                cmd.CommandText = "SELECT EmployeeId AS ID, FirstName AS First, MiddleInitial AS Middle, LastName AS Last," +
                    "EmailAddress AS Email, PhoneNumber AS Number, Title, DateOfBirth AS Bday FROM Employees";

                MySqlDataReader reader = cmd.ExecuteReader();

                List<Employee> employees = new List<Employee>();
                while (reader.Read())
                {
                    Employee emp = new Employee
                    {
                        EmployeeId = (int)reader["ID"],
                        FirstName = reader["First"].ToString(),
                        MiddleInitial = reader["Middle"].ToString(),
                        LastName = reader["Last"].ToString(),
                        EmailAddress = reader["Email"].ToString(),
                        PhoneNumber = reader["Number"].ToString(),
                        Title = reader["Title"].ToString(),
                        DateOfBirth = Convert.ToDateTime(reader["Bday"])
                    };
                    employees.Add(emp);
                }
                return employees;
            }
        }

        public void CreateEmployees(Employee createEmployees)
        {
            MySqlConnection connect = new MySqlConnection(connectionString);

            using (connect)
            {
                connect.Open();
                MySqlCommand cmd = connect.CreateCommand();
                cmd.CommandText = "INSERT INTO employees (FirstName, MiddleInitial," +
                    "LastName, EmailAddress, PhoneNumber, Title, DateOfBirth) VALUES" +
                    "( @First, @Middle, @Last, @Email, @Number,@Title,@Bday);";
                cmd.Parameters.AddWithValue("First", createEmployees.FirstName);
                cmd.Parameters.AddWithValue("Middle", createEmployees.MiddleInitial);
                cmd.Parameters.AddWithValue("Last", createEmployees.LastName);
                cmd.Parameters.AddWithValue("Email", createEmployees.EmailAddress);
                cmd.Parameters.AddWithValue("Title", createEmployees.Title);
                cmd.Parameters.AddWithValue("Number", createEmployees.PhoneNumber);
                cmd.Parameters.AddWithValue("BDay", createEmployees.DateOfBirth);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateEmployees(int employeeID, string firstName, string lastName, string middleInitial)
        {
            MySqlConnection connect = new MySqlConnection(connectionString);
            using (connect)
            {
                connect.Open();
                MySqlCommand cmd = connect.CreateCommand();
                cmd.CommandText = "UPDATE Employees SET FirstName=@First,LastName=@Last, MiddleInitial=@Middle "
                    + "WHERE EmployeeId=@ID;";
                cmd.Parameters.AddWithValue("ID", employeeID);
                cmd.Parameters.AddWithValue("First", firstName);
                cmd.Parameters.AddWithValue("Last", lastName);
                cmd.Parameters.AddWithValue("Middle", middleInitial);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteEmployees(int employeeID)
        {
            MySqlConnection connect = new MySqlConnection(connectionString);
            using (connect)
            {
                connect.Open();
                MySqlCommand cmd = connect.CreateCommand();
                cmd.CommandText = "DELETE FROM Employees WHERE EmployeeId=@ID ;";
                cmd.Parameters.AddWithValue("ID", employeeID);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Employee> SearchEmployees(string firstName, string lastName)
        {
            MySqlConnection connect = new MySqlConnection(connectionString);

            using (connect)
            {
                connect.Open();
                MySqlCommand cmd = connect.CreateCommand();
                cmd.CommandText = "SELECT EmployeeId AS ID, FirstName AS First, MiddleInitial AS Middle, LastName AS Last," +
                    "EmailAddress AS Email, PhoneNumber As Number, Title, DateOfBirth AS Bday FROM Employees WHERE LastName LIKE @Last AND FirstName like @First ;";
                cmd.Parameters.AddWithValue("First", "%" + firstName + "%");
                cmd.Parameters.AddWithValue("Last", "%" + lastName + "%");

                MySqlDataReader reader = cmd.ExecuteReader();

                List<Employee> employees = new List<Employee>();
                while (reader.Read())
                {
                    Employee emp = new Employee
                    {
                        EmployeeId = (int)reader["ID"],
                        FirstName = reader["First"].ToString(),
                        MiddleInitial = reader["Middle"].ToString(),
                        LastName = reader["Last"].ToString(),
                        EmailAddress = reader["Email"].ToString(),
                        PhoneNumber = reader["Number"].ToString(),
                        Title = reader["Title"].ToString(),
                        DateOfBirth = Convert.ToDateTime(reader["Bday"])
                    };
                    employees.Add(emp);
                }
                return employees;
            }
        }
    }
}

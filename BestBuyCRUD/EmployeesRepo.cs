using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace BestBuyCRUD
{
    class EmployeesRepo
    {
        public string connectionString; // field

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
                    "EmailAddress AS Email, PhoneNumber As Number, Title, DateOfBirth AS Bday FROM Employees";

                MySqlDataReader reader = cmd.ExecuteReader();

                List<Employees> employees = new List<Employees>();
                while(reader.Read())
                {
                    Employees emp = new Employees
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

        public void CreateEmployees(Employees createEmployees)
        {
            MySqlConnection connect= new MySqlConnection(connectionString);

            using (connect)
            {
                connect.Open();
                MySqlCommand cmd = connect.CreateCommand();
                cmd.CommandText = "INSERT INTO employees (FirstName, MiddleInitial," +
                    "LastName, EmailAddress, PhoneNumber, Title, DateOfBirth) VALUES" +
                    "( @First, @Middle, @Last, @Email, @Number,@Title,@Bday);";
               // cmd.Parameters.AddWithValue("ID", createEmployees.EmployeeId);
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


        public void UpdateEmployees(int eId,string fn, string ln, string m )
        {
            MySqlConnection connect = new MySqlConnection(connectionString);
            using (connect)
            {
                connect.Open();
                MySqlCommand cmd = connect.CreateCommand();
                cmd.CommandText = "UPDATE Employees SET FirstName=@First,LastName=@Last, MiddleInitial=@Middle "
                    + "Where EmployeeId=@ID;";

                cmd.Parameters.AddWithValue("ID", eId);
                cmd.Parameters.AddWithValue("First", fn);
                cmd.Parameters.AddWithValue("Last", ln);
                cmd.Parameters.AddWithValue("Middle", m);
                // cmd.Parameters.AddWithValue("Email", EmailAddress);
                // cmd.Parameters.AddWithValue("Phone", DateOfBirth);
                //cmd.Parameters.AddWithValue("Bday", DateOfBirth);

                cmd.ExecuteNonQuery();
            } 
               
        }


        public void DeleteEmployees (int eId)
        {
            MySqlConnection connect = new MySqlConnection(connectionString);
            using (connect)
            {
                connect.Open();
                MySqlCommand cmd = connect.CreateCommand();
                cmd.CommandText = "DELETE FROM Employees Where EmployeeId=@ID ;";
                cmd.Parameters.AddWithValue("ID", eId);
                //cmd.Parameters.AddWithValue("ID", eId2);
                // cmd.Parameters.AddWithValue("First",employeesToDelete.FirstName);
                //cmd.Parameters.AddWithValue("Middle", employeesToDelete.MiddleInitial);
                //cmd.Parameters.AddWithValue("Email", employeesToDelete.EmailAddress);
                //cmd.Parameters.AddWithValue("Phone", employeesToDelete.DateOfBirth);
                //cmd.Parameters.AddWithValue("Bday", employeesToDelete.DateOfBirth);

                cmd.ExecuteNonQuery();
            }
        }

        public void SearchEmployees(string fName, string lName)
        {
            MySqlConnection connect = new MySqlConnection(connectionString);

            using (connect)
            {
                connect.Open();
                MySqlCommand cmd = connect.CreateCommand();
                cmd.CommandText = "Select * from employees where LastName like'%" + lName + "%' AND FirstName like '%" + fName + "%';";
              
                // cmd.Parameters.AddWithValue("ID", createEmployees.EmployeeId);
                cmd.Parameters.AddWithValue("First", fName);
                //cmd.Parameters.AddWithValue("Middle", createEmployees.MiddleInitial);
                cmd.Parameters.AddWithValue("Last",lName);
                //cmd.Parameters.AddWithValue("Email", createEmployees.EmailAddress);
                //cmd.Parameters.AddWithValue("Title", createEmployees.Title);
                //cmd.Parameters.AddWithValue("Number", createEmployees.PhoneNumber);
                //cmd.Parameters.AddWithValue("BDay", createEmployees.DateOfBirth);

                cmd.ExecuteNonQuery();
            }
        }

    }
}

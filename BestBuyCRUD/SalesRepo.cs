using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace BestBuyCRUD
{
    class SalesRepo
    {
        public string connectionString;
        public SalesRepo(string conn)
        {
            connectionString = conn;
        }

        public List<Sales> GetSales()
        {
            MySqlConnection connect = new MySqlConnection(connectionString);

            using (connect)
            {
                connect.Open();
                MySqlCommand cmd = connect.CreateCommand();
                cmd.CommandText = "SELECT SalesID AS SID, ProductId AS PID, Quantity AS Q,"
                    + "Price, Date, EmployeeID AS EID FROM Sales;";

                MySqlDataReader reader = cmd.ExecuteReader();

                List<Sales> sales = new List<Sales>();
                while (reader.Read())
                {
                    Sales s = new Sales
                    {
                        SalesId = (int)reader["SID"],
                        ProductId = (int)reader["PID"],
                        Quantity = (int)reader["Q"],
                        Price = (decimal)reader["Price"],
                        Date = Convert.ToDateTime(reader["Date"]),
                        EmployeeId = (int)reader["EID"]
                    };
                    sales.Add(s);
                }
                return sales;
            }
        }

        public void CreateSales(int productID, int quantity, decimal price, DateTime date, int employeeID)
        {
            MySqlConnection connect = new MySqlConnection(connectionString);

            using (connect)
            {
                connect.Open();
                MySqlCommand cmd = connect.CreateCommand();
                cmd.CommandText = "INSERT INTO Sales( ProductID, Quantity, Price, Date, Employeeid)"
                    + "VALUES(@PID,@Q, @Price, @Date, @EID);";
                cmd.Parameters.AddWithValue("PID", productID);
                cmd.Parameters.AddWithValue("Q", quantity);
                cmd.Parameters.AddWithValue("Price", price);
                cmd.Parameters.AddWithValue("Date", date);
                cmd.Parameters.AddWithValue("EID", employeeID);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateSales(Sales salesToUpdate)
        {
            MySqlConnection connect = new MySqlConnection(connectionString);
            using (connect)
            {
                connect.Open();
                MySqlCommand cmd = connect.CreateCommand();

                cmd.CommandText = "UPDATE Sales SET  ProductId =@PID, Quantity=@Q, Price=@price, Date=@date WHERE EmployeeID=@EID;";
                cmd.Parameters.AddWithValue("PID", salesToUpdate.ProductId);
                cmd.Parameters.AddWithValue("Q", salesToUpdate.Quantity);
                cmd.Parameters.AddWithValue("Price", salesToUpdate.Price);
                cmd.Parameters.AddWithValue("Date", salesToUpdate.Date);
                cmd.Parameters.AddWithValue("EID", salesToUpdate.EmployeeId);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteSales(int employeeID)
        {
            MySqlConnection connect = new MySqlConnection(connectionString);
            using (connect)
            {
                connect.Open();
                MySqlCommand cmd = connect.CreateCommand();
                cmd.CommandText = "DELETE FROM Sales WHERE EmployeeID=@EID;";
                cmd.Parameters.AddWithValue("EID", employeeID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

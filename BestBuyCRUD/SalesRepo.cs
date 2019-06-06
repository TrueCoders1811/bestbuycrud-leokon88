using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace BestBuyCRUD
{
    class SalesRepo
    {
        public string connectionString; // field

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
                    + "Price, Date, EmployeeID AS EID";

                MySqlDataReader reader = cmd.ExecuteReader();

                List<Sales> sales = new List<Sales>();
                while(reader.Read())
                {
                    Sales s = new Sales();
                    s.SalesId = (int)reader["SID"];
                    s.ProductId = (int)reader["PID"];
                    s.Quantity = (int)reader["Q"];
                    s.Price = (decimal)reader["Price"];
                    s.Date = Convert.ToDateTime(reader["Date"]);
                    s.EmployeeId = (int)reader["EID"];
                }
                return sales;
            }
        }

        public void CreateSales(Sales salesToCreate)
        {
            MySqlConnection connect = new MySqlConnection(connectionString);

            using (connect)
            {
                connect.Open();

                MySqlCommand cmd = connect.CreateCommand();
                cmd.CommandText = "INSERT INTO Sales(SalesID, ProductID, Quantity, Price,Date,EmployeesID)"
                    + "(@SID,@PID,@Q, @Price, @Date, @EID)";
                cmd.Parameters.AddWithValue("SID", salesToCreate);
                cmd.Parameters.AddWithValue("PID", salesToCreate);
                cmd.Parameters.AddWithValue("Q", salesToCreate);
                cmd.Parameters.AddWithValue("Price", salesToCreate);
                cmd.Parameters.AddWithValue("Date", salesToCreate);
                cmd.Parameters.AddWithValue("EID", salesToCreate);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateSales(Sales salesToUpate)
        {
            MySqlConnection connect = new MySqlConnection(connectionString);

            using (connect)
            {
                connect.Open();
                MySqlCommand cmd = connect.CreateCommand();

                cmd.CommandText = "Update Sales SET SalesId =@SID, ProductId =@PID, Quantity=@Q"
                    + "Price=@price, Date=@date, EmployeeID=@EID";
                cmd.Parameters.AddWithValue("SID", salesToUpate.SalesId);
                cmd.Parameters.AddWithValue("PID", salesToUpdate.ProductId);
                cmd.Parameters.AddWithValue("Q", salesToUpdate.Quantity);
                cmd.Parameters.AddWithValue("Price", salesToUpdate.Price);
                cmd.Parameters.AddWithValue("Date", salesToUpdate.Date);
                cmd.Parameters.AddWithValue("EID", salesToUpdate.EmployeeId);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteSales( Sales salesToDelete)
        {
            MySqlConnection connect = new MySqlConnection(connectionString);
            using (connect)
            {
                connect.Open();

                MySqlCommand cmd = connect.CreateCommand();
                cmd.CommandText = "DELECT FROM Sales ??";
                cmd.Parameters.AddWithValue("SID", salesToDelete.SalesId);
                cmd.Parameters.AddWithValue("PID", salesToDelete.ProductId);
                cmd.Parameters.AddWithValue("Price", salesToDelete.Price);
                cmd.Parameters.AddWithValue("Q", salesToDelete.Quantity);
                cmd.Parameters.AddWithValue("EID", salesToDelete.EmployeeId);
                cmd.Parameters.AddWithValue("Date", salesToDelete.Date);

                cmd.ExecuteNonQuery();
            }
        }


    }

}

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
                    s.Price = (int)reader["Price"];
                    s.Date = Convert.ToDateTime(reader["Date"]);
                    s.EmployeeId = (int)reader["EID"];
                }
            }
        }
    }

}

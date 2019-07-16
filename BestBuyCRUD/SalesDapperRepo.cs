using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using MySql.Data.MySqlClient;
using System.Linq;

/*namespace BestBuyCRUD
{
    /class SalesDapperRepo : ISalesRepository  //adding interface inheritance
    {
        private string connectionString;
        public SalesDapperRepo(string connString)  // pass constructionstring
        { 
            connectionString = connString;
        }

        // option: Create constructor for connection  to call only once

        public void CreateSales(Sales sales)
        {
            MySqlConnection connect = new MySqlConnection(connectionString);
            using (connect)
            {
                connect.Open();
                string sqlCmd = "INSERT INTO Sales(SalesID, ProductID, Quantity, Price,Date,EmployeesID)"
                    + "(@SalesID,@ProductId, @Quantity, @Price,@Date,@EmployeesId)";
                connect.Execute(sqlCmd, sales);

            }
        }

        public void DeleteSales(int saleId)
        {
            MySqlConnection connect = new MySqlConnection(connectionString);
            using (connect)
            {
                connect.Open();
                string sqlCmd = "Delete From sales Where salesId = @SaleId)";
                connect.Execute(sqlCmd, new { saleId });//pass anonymous type (class) since we are not passing entire sales
            }
        }
        
        public List<Sales> GetSales()
        {
            MySqlConnection connect = new MySqlConnection(connectionString);
            using (connect)
            {
                connect.Open();
                string sqlCmd = "SELECT SalesId, ProductID FROM Sales";//names must match exactly as specified in Class
                return connect.Query<Sales>(sqlCmd).ToList();  //Query  - Dapper method .ToList - Linq method allows to convert arrays to list

                
               }
        }

        public void UpdateSales(Sales sales)
        {
            throw new NotImplementedException();
        }
    }
}
*/
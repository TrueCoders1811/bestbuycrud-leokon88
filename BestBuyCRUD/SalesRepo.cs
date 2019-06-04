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

    }
}

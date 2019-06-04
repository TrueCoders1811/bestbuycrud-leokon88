using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyCRUD
{
    class Sales
    {
        public int SalesId { get; set; } // property
        public int ProductId { get; set; }
        public int Quality { get; set; }
        public int Price{ get; set; }
        public DateTime DateOfBirth { get; set; }
        public int EmployeeId { get; set; }
    }
}

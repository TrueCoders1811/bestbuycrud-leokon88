﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyCRUD
{
    class Sales
    {
        public int SalesId { get; set; } // property
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price{ get; set; }
        public DateTime Date { get; set; }
        public int EmployeeId { get; set; }
    }
}

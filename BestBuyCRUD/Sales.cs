using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyCRUD
{
    class Sales
    {
        public int SalesId { get; set; } // property
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public int EmployeeId { get; set; }

        public static Sales SalesInfo(int eID)
        {
            int pID = Program.GetIntValue("Enter Product ID: ");
            int q = Program.GetIntValue("Enter Quantity sold: ");
            Console.WriteLine("Enter Price: ");
            string priceInput = Console.ReadLine();
            decimal price;
            decimal.TryParse(priceInput, out price);
          
            Console.WriteLine("Enter Date of Sales: yyyy-mm-dd");
            var dateInput = Console.ReadLine();
            DateTime sDate;
            DateTime.TryParse(dateInput, out sDate);

            Sales newSale = new Sales(pID, q, price, sDate, eID);
            return newSale;
        }

        public Sales(int pid, int q, decimal p, DateTime date, int eid)
        {
            ProductId = pid;
            Quantity = q;
            Price = p;
            Date = date;
            EmployeeId = eid;
        }
        public Sales()
        {

        }
    }
}

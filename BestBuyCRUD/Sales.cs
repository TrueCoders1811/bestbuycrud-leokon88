using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyCRUD
{
    class Sales
    {
        public int SalesId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public int EmployeeId { get; set; }

        public static Sales SalesInfo(int employeeID)
        {
            int productID = Program.GetIntValue("Enter Product ID: ");
            int quantity = Program.GetIntValue("Enter Quantity sold: ");
            Console.WriteLine("Enter Price: ");
            string priceInput = Console.ReadLine();
            decimal price;
            decimal.TryParse(priceInput, out price);

            Console.WriteLine("Enter Date of Sales: yyyy-mm-dd");
            var dateInput = Console.ReadLine();
            DateTime salesDate;
            DateTime.TryParse(dateInput, out salesDate);

            Sales newSale = new Sales(productID, quantity, price, salesDate, employeeID);
            return newSale;
        }

        public Sales(int productID, int quantity, decimal price, DateTime date, int employeeID)
        {
            ProductId = productID;
            Quantity = quantity;
            Price = price;
            Date = date;
            EmployeeId = employeeID;
        }
        public Sales()
        {
        }
    }
}

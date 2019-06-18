using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyCRUD
{
    class Employees
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Title { get; set; }
        public DateTime DateOfBirth { get; set; }


        public static Employees EmployeeInfo()
        {
            Console.WriteLine("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Middle Initial: ");
            string middleName = Console.ReadLine();
            Console.WriteLine("Enter Email Address:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Phone number: (000-000-0000)");
            string number = Console.ReadLine();
            Console.WriteLine("Enter Position Title:");
            string title = Console.ReadLine();
            Console.WriteLine("Enter Date of Birth: yyyy-mm-dd");
            var bDate = Console.ReadLine();
            DateTime result;
            DateTime.TryParse(bDate, out result);

            Employees newEmployee = new Employees(firstName, middleName, lastName, email, number, title, result);
            return newEmployee;
        }

        public Employees( string fName, string mi,string lName, string email, string number, string title, DateTime bday) // constructor created to create a new employee
           {
               FirstName = fName;
               MiddleInitial = mi;
               LastName = lName;
               EmailAddress = email;
               PhoneNumber = number;
               Title = title;
               DateOfBirth = bday;
           }
        public Employees()
        {

        }

        public Employees(string fName,  string lName)
        {
            FirstName = fName;
            LastName = lName;
        }
        // contructor 

    }
}

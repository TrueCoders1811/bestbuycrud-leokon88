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
        // contructor 

    }
}

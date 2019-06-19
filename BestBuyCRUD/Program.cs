using System;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;


namespace BestBuyCRUD
{
    class Program
    {
        public static int GetIntValue(string question)
        {

            while (true)
            {
                int result;
                Console.WriteLine(question);
                string input = Console.ReadLine();
                bool isNumber = int.TryParse(input, out result);

                if (isNumber)
                {
                    return result;
                }
                Console.Clear();
                Console.WriteLine("Not a number! Type a number");
            }

        }



        static void Main(string[] args)
        {
            string jsonData = File.ReadAllText("AppSetting.Debug.json");

            string connString = JObject.Parse(jsonData)["ConnectionStrings"]["DefaultConnection"].ToString();

            EmployeesRepo er = new EmployeesRepo(connString);
            SalesRepo sr = new SalesRepo(connString);


            // add prompt to ask for new id#
            // or menu with switch case. 
            //while loop to continue ask for user input 
            //Console.Clear()
            bool isTrue = false;


            //Console.Clear();
            while (!isTrue)
            {

                List<Employees> listOfEmployees = er.GetEmployees();
                int employeeCount = listOfEmployees.Count - 1; // getting last index of employee 
                int lastEmployeeId = listOfEmployees[employeeCount].EmployeeId;// retrieving employeeId from last employee in the listOfEmployees list)

                int userInput = GetIntValue("Select from the Menu:" +
                    "\n 1) Create a new employee" +
                    "\n 2) Update last employee" +
                    "\n 3) Delete last  employee" +
                    "\n 4) Display an complete employee list" +
                    "\n 5) Search for an employee" +
                    $"\n 6) Create a sales for an employee {lastEmployeeId}" +
                    "\n 7) Exit");

                Console.Clear();
                switch (userInput)
                {
                    case 1:
                        //Create new employee

                        Employees newEmployee = Employees.EmployeeInfo();
                        er.CreateEmployees(newEmployee);
                        Console.WriteLine("New employee created.");
                        break;

                    case 2:
                        //Update last Employee info
                        Employees updateEmployee = Employees.EmployeeInfo();
                        er.UpdateEmployees(lastEmployeeId, updateEmployee.FirstName, updateEmployee.LastName, updateEmployee.MiddleInitial);
                        Console.WriteLine($"Employee {lastEmployeeId} updated.");
                        break;
                    case 3:
                        //Delete last Employee info
                        Console.WriteLine($"Are you sure you want to delete Employee# {lastEmployeeId} ?");
                        er.DeleteEmployees(lastEmployeeId);
                        Console.WriteLine($"Employee# {lastEmployeeId} deleted");
                        break;
                    case 4:
                        Console.WriteLine("Employee List:");
                        foreach (Employees emp in listOfEmployees)
                        {
                            Console.WriteLine($"ID: {emp.EmployeeId}   FirstName: {emp.FirstName}  MiddleInitial: {emp.MiddleInitial}"
                                + $"LastName:{emp.LastName}  Email: {emp.EmailAddress}   Phone:{emp.PhoneNumber}  Title: {emp.Title}  Date of Birth : {emp.DateOfBirth}");
                        }
                        //Console.Read();
                        break;
                    case 5:
                        // search employee info by first and last name
                        Console.WriteLine("Enter an employee's first name");
                        string searchFName = Console.ReadLine();
                        Console.WriteLine("Enter an employee's last name");
                        string searchLName = Console.ReadLine();
                        List<Employees> searchEmployee = er.SearchEmployees(searchFName, searchLName);

                        foreach (Employees emp in searchEmployee)
                        {
                            Console.WriteLine($"ID: {emp.EmployeeId}   FirstName: {emp.FirstName}  MiddleInitial: {emp.MiddleInitial}"
                                + $"LastName:{emp.LastName}  Email: {emp.EmailAddress}   Phone:{emp.PhoneNumber}  Title: {emp.Title}  Date of Birth : {emp.DateOfBirth}");
                        }
                        break;
                    case 6:
                        //Create new sale
                        Sales newSale = Sales.SalesInfo( lastEmployeeId);
                        sr.CreateSales(newSale.ProductId, newSale.Quantity, newSale.Price,newSale.Date, newSale.EmployeeId);
                        Console.WriteLine("New sale created.");
                        break;


                    case 7:
                        Console.WriteLine("Exiting Menu ");

                        isTrue = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Enter 1 through 6.");
                        break;
                }

            }

        }


    }
}



/*
 * Intructions:
 * 1. Start by creating a json file to store your connection string, and making sure it is hidden by git.
 * 2. Grab your connection string from the json file and into a string in the main method.
 * 3. Create 4 classes:
 *    a. Sales - will contain a property for each field / column in the sales table in the bestbuy database.
 *    b. Employees - will contain a property for each field / column in the employees table in the bestbuy database.
 *    c. SalesRepo - will contain the 4 CRUD operations for the sales table.
 *    d. EmployeesRepo - will contain the 4 CRUD operations for the employees table.
 * 4. The two repo classes will need constructors that take in a connection string.
 * 5. Back in the Main method, you will have to successfully demonstrate each CRUD operation works:
 *    a. Create a employee and a sale made by that employee.
 *    b. Update some information for the created employee.
 *    c. Read Information from both the sales and employees tables.
 *    d. Delete the created employee and all the sales they have made.
 * 
 * Make sure you are making commits along the way! 
 * When you are done, push your branch to github and create a pull request. Do not merge!
 * 
 * Bonus: Create a method(s) in the EmployeesRepo class that search for employees by their first / last name, or both.
 */




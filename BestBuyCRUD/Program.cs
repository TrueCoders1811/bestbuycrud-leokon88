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

            bool shouldEexit = false;

            while (!shouldEexit)
            {
                List<Employee> listOfEmployees = er.GetEmployees();
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
                    case 1: //Create new employee
                        Employee newEmployee = Employee.EmployeeInfo();
                        er.CreateEmployees(newEmployee);
                        Console.WriteLine("New employee created.");
                        break;

                    case 2:  //Update last Employee info
                        Employee updateEmployee = Employee.EmployeeInfo();
                        er.UpdateEmployees(lastEmployeeId, updateEmployee.FirstName, updateEmployee.LastName, updateEmployee.MiddleInitial);
                        Console.WriteLine($"Employee {lastEmployeeId} updated.");
                        break;
                    case 3://Delete last Employee info
                        er.DeleteEmployees(lastEmployeeId);
                        Console.WriteLine($"Employee# {lastEmployeeId} deleted");
                        break;
                    case 4: // Display the list of Employees
                        Console.WriteLine("Employee List:");
                        foreach (Employee emp in listOfEmployees)
                        {
                            Console.WriteLine($"ID: {emp.EmployeeId}   FirstName: {emp.FirstName}  MiddleInitial: {emp.MiddleInitial}"
                                + $"LastName:{emp.LastName}  Email: {emp.EmailAddress}   Phone:{emp.PhoneNumber}  Title: {emp.Title}  Date of Birth : {emp.DateOfBirth}");
                        }
                        break;
                    case 5:   // search employee info by first and last name
                        Console.WriteLine("Enter the employee's first name");
                        string searchFName = Console.ReadLine();
                        Console.WriteLine("Enter the employee's last name");
                        string searchLName = Console.ReadLine();
                        List<Employee> searchEmployee = er.SearchEmployees(searchFName, searchLName);

                        foreach (Employee emp in searchEmployee)
                        {
                            Console.WriteLine($"ID: {emp.EmployeeId}   FirstName: {emp.FirstName}  MiddleInitial: {emp.MiddleInitial}"
                                + $"LastName:{emp.LastName}  Email: {emp.EmailAddress}   Phone:{emp.PhoneNumber}  Title: {emp.Title}  Date of Birth : {emp.DateOfBirth}");
                        }
                        break;
                    case 6://Create new sale for last employee created
                        Sales newSale = Sales.SalesInfo(lastEmployeeId);
                        sr.CreateSales(newSale.ProductId, newSale.Quantity, newSale.Price, newSale.Date, newSale.EmployeeId);
                        Console.WriteLine("New sales created.");
                        break;
                    case 7: // Exit menu
                        Console.WriteLine("Exiting Menu ");
                        shouldEexit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Enter 1 through 6.");
                        break;
                }

            }

        }
    }
}


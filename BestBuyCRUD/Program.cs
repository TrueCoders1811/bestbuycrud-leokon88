using System;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;


namespace BestBuyCRUD
{
    class Program
    {
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

                Console.WriteLine("Select from the Menu:");
                Console.WriteLine("1) Create a new employee");
                Console.WriteLine("2) Update last employee");
                Console.WriteLine("3) Delete last  employee");
                Console.WriteLine("4) Display an complete employee list");
                Console.WriteLine("5) Search for an employee");
                Console.WriteLine("6) Exit");

                int userInput = int.Parse(Console.ReadLine());
                Console.Clear();
            
               List<Employees> listOfEmployees = er.GetEmployees();
               int employeeCount = listOfEmployees.Count - 1; // getting last index of employee 
               int lastEmployeeId = listOfEmployees[employeeCount].EmployeeId;// retrieving employeeId from last employee in the listOfEmployees list)

                switch (userInput)
                {
                        case 1:
                        //Create new employee
                        Console.WriteLine("Enter First Name: ");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Enter Last Name: ");
                        string lastName = Console.ReadLine();
                        Console.WriteLine("Enter Middle Initial: ");
                        string middleName = Console.ReadLine();
                        Console.WriteLine("Enter Email Address:");
                        string email = Console.ReadLine();
                        Console.WriteLine("Enter Phone number:");
                        string number = Console.ReadLine();
                        Console.WriteLine("Enter Position Title:");
                        string title = Console.ReadLine();
                        DateTime today = DateTime.Now;

                        Employees newEmployee = new Employees(firstName, middleName, lastName, email, number, title, today);// constructor created to create a new employee
                        er.CreateEmployees(newEmployee);
                        Console.WriteLine("New employee created.");
                        break;

                    case 2:
                        //Update last Employee info
                        er.UpdateEmployees(lastEmployeeId,"Thomas" , "S", "Lim");
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
                        Console.Read();
                        break;
                    case 5:
                        Console.WriteLine("Enter an employee # to search");
                        int empSearch =int.Parse(Console.ReadLine());
                        Console.WriteLine($"ID: {emp.EmployeeId}   FirstName: {emp.FirstName}  MiddleInitial: {emp.MiddleInitial}"
                                + $"LastName:{emp.LastName}  Email: {emp.EmailAddress} ");
                        break;
                    case 6:
                        Console.WriteLine("Exiting Menu ");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Enter 1 through 6.");
                        break;
                }

            }
        }


    }
}



        // List <Employees> listOfEmployees= er.GetEmployees();

        /* foreach(Employees emp in listOfEmployees)
          {
              Console.WriteLine($"ID: {emp.EmployeeId}   FirstName: {emp.FirstName}  MiddleInitial: {emp.MiddleInitial}"
                  +$"LastName:{emp.LastName}  Email: {emp.EmailAddress}   Phone:{emp.PhoneNumber}  Title: {emp.Title}  Date of Birth : {emp.DateOfBirth}"); 
          }
           Console.Read();
         */
        //  int employeeCount = listOfEmployees.Count-1; // getting last index of employee 
        // int lastEmployeeId = listOfEmployees[employeeCount].EmployeeId; //retrieving employeeId from last employee in the listOfEmployees list) 

        //Create new sale
        //   Sales lastSale = new Sales(2, 3, 1600, new DateTime(2019, 06, 15, 15, 22, 00), lastEmployeeId) ;// constructor created to create new sale for last employee
        // sr.CreateSales(lastSale); 

        /*  List<Sales> sales = sr.GetSales();
          foreach (Sales trans in sales)
          {
              Console.WriteLine($"SalesID: {trans.SalesId}  ProductID: {trans.ProductId}  Quantity: {trans.Quantity} "
                  + $"Price:{trans.Price}   Date:{trans.Date}  EmployeeId: {trans.EmployeeId} ");
          }
          Console.Read();
          */

        //Update Employee info
        //   er.UpdateEmployees(lastEmployeeId,"hhh" , "S", "Lim");
        //  Console.WriteLine("Employee data updated");

        /*  sr.DeleteSales(lastEmployeeId);
           er.DeleteEmployees(lastEmployeeId );
           Console.WriteLine("Employee data deleted");
           */
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
    
    


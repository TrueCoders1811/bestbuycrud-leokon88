# BestBuyCRUD
A project to test ability to run CRUD operations on a database.


## Instructions
1. Clone the repository and create a branch to work on.
2. Start by creating a json file to store your connection string, and making sure it is hidden by git.
3. Grab your connection string from the json file and into a string in the main method.
4. Create 4 classes:
   * Sales - will contain a property for each field / column in the sales table in the bestbuy database.
   * Employees - will contain a property for each field / column in the employees table in the bestbuy database.
   * SalesRepo - will contain the 4 CRUD operations for the sales table.
   * EmployeesRepo - will contain the 4 CRUD operations for the employees table.
5. The two repo classes will need constructors that take in a connection string.
6. Back in the Main method, you will have to successfully demonstrate each CRUD operation works:
   * Create a employee and a sale made by that employee.
   * Update some information for the created employee.
   * Read Information from both the sales and employees tables.
   * Delete the created employee and all the sales they have made.

Make sure you are making commits along the way!
When you are done, push your branch to github and create a pull request. **Do not merge!**

**Bonus: Create a method(s) in the EmployeesRepo class that search for employees by their first / last name, or both.**


using CommonLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; // Namespace for asynchronous programming

namespace DataAccessLayer
{
    public class DbEmployeeOperation                   // Class for employee database operations
    {
        DatabaseConnection dbconnect;                  // Instance of DatabaseConnection to manage DB connection
        public DbEmployeeOperation()
        {
            dbconnect = new DatabaseConnection();
        }

        // Method to retrieve all employees
        public List<Employee> GetEmployees()
        {
            List<Employee> empList = new List<Employee>();                   // List to hold employee records

            SqlCommand cmd = new SqlCommand("sp_Employee", dbconnect.connection);               // Command for stored procedure
            if (dbconnect.connection.State == ConnectionState.Closed)                          // Check if the connection is closed
            {
                dbconnect.connection.Open();                // Open the connection if it is closed

            }
            cmd.CommandType = CommandType.StoredProcedure;                // Set command type to stored procedure
            cmd.Parameters.AddWithValue("@action", "SelectAll");            // Add parameter for action
            SqlDataReader dr = cmd.ExecuteReader();                   // Execute the command and get data reader
            while (dr.Read())                           // Read data from the data reader
            {
                Employee emp = new Employee();         // Create new employee object
                emp.Eid = (int)dr["eid"];                   // Assign employee ID
                emp.Name = dr["ename"].ToString();
                emp.Age = (int)dr["eage"];
                emp.Address = dr["Eaddress"].ToString();
                emp.Post = dr["epost"].ToString();
                emp.Salary = (decimal)dr["esalary"];
                empList.Add(emp);                             // Add employee to the list
            }
            dbconnect.connection.Close();              // Close the database connection
            return empList;                     // Return the list of employees
        }
        // Method to add a new employee
        public bool AddEmployee(Employee empObj)
        {
            if (dbconnect.connection.State == ConnectionState.Closed)
            {
                dbconnect.connection.Open();

            }
            SqlCommand cmd = new SqlCommand("sp_Employee", dbconnect.connection);
            cmd.CommandType = CommandType.StoredProcedure;                                  // Set command type to stored procedure
            cmd.Parameters.AddWithValue("@name", empObj.Name);                            // Add employee name parameter
            cmd.Parameters.AddWithValue("@age", empObj.Age);
            cmd.Parameters.AddWithValue("@address", empObj.Address);
            cmd.Parameters.AddWithValue("@post", empObj.Post);
            cmd.Parameters.AddWithValue("@salary", empObj.Salary);
            cmd.Parameters.AddWithValue("@action", "Create");                    // Add action parameter for creation
            int n = cmd.ExecuteNonQuery();                          // Execute the command and get the number of rows affected
            dbconnect.connection.Close();
            if (n != 0)                             // Return true if rows affected, otherwise false
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        // Method to retrieve a single employee by ID
        public Employee GetEmployees(int empId)
        {
            List<Employee> empList = new List<Employee>();

            SqlCommand cmd = new SqlCommand("sp_Employee", dbconnect.connection);        // Command for stored procedure
            if (dbconnect.connection.State == ConnectionState.Closed)                   // Check if the connection is closed   
            { 
                dbconnect.connection.Open();

            }
            cmd.CommandType = CommandType.StoredProcedure;                  // Set command type to stored procedure
            cmd.Parameters.AddWithValue("@action", "Select_Single");          // Add action parameter for single selection
            cmd.Parameters.AddWithValue("@id", empId);
            SqlDataReader dr = cmd.ExecuteReader();                 // Execute the command and get data reader
            Employee emp = new Employee();                    // Create new employee object
            if (dr.Read())                      // Read data from the data reader
            {
                emp.Eid = (int)dr["eid"];
                emp.Name = dr["ename"].ToString();       // Assign employee name
                emp.Age = (int)dr["eage"];                   // Assign employee age
                emp.Address = dr["Eaddress"].ToString();
                emp.Post = dr["epost"].ToString();
                emp.Salary = (decimal)dr["esalary"];
            }
            dbconnect.connection.Close();
            return emp;                           // Return the employee object
        }
        // Method to update an existing employee
        public bool UpdateEmployee(Employee empObj)
        {
            if (dbconnect.connection.State == ConnectionState.Closed)
            {
                dbconnect.connection.Open();

            }
            SqlCommand cmd = new SqlCommand("sp_Employee", dbconnect.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", empObj.Eid);
            cmd.Parameters.AddWithValue("@name", empObj.Name);
            cmd.Parameters.AddWithValue("@age", empObj.Age);
            cmd.Parameters.AddWithValue("@address", empObj.Address);
            cmd.Parameters.AddWithValue("@post", empObj.Post);
            cmd.Parameters.AddWithValue("@salary", empObj.Salary);
            cmd.Parameters.AddWithValue("@action", "Update");
            int n = cmd.ExecuteNonQuery();
            dbconnect.connection.Close();
            if (n != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Method to delete an employee by ID
        public bool DeleteEmployee(int EmpId)
        {
            if (dbconnect.connection.State == ConnectionState.Closed)
            {
                dbconnect.connection.Open();

            }
            SqlCommand cmd = new SqlCommand("sp_Employee", dbconnect.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id",EmpId);
            cmd.Parameters.AddWithValue("@action", "Delete");                // Add action parameter for deletion
            int n = cmd.ExecuteNonQuery();
            dbconnect.connection.Close();
            if (n != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

}   }


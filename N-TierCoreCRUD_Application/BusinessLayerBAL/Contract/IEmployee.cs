using CommonLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerBAL.Contract
{
    // Interface defining employee-related operations
    public interface IEmployee
    {
        List<Employee> GetEmployees();       // Method to retrieve a list of all employees
        bool AddEmployee(Employee empObj);
        Employee GetEmployee(int empid);
        bool UpdateEmployee(Employee empObj); // Method to update an existing employee's details
        bool DeleteEmployee(int empid);
    }
}

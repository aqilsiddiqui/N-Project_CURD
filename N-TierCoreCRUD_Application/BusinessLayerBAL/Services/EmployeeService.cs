using BusinessLayerBAL.Contract;
using CommonLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerBAL.Services
{
    public class EmployeeService :IEmployee
    {
        DbEmployeeOperation dbEmp;
        public EmployeeService()
        {
            dbEmp = new DbEmployeeOperation();
        }
        public bool AddEmployee(Employee empObj)
        {
            return dbEmp.AddEmployee(empObj);
        }
        public Employee GetEmployee(int empid)
        {
           return dbEmp.GetEmployees(empid);
        }
        public List<Employee> GetEmployees()
        {
            return dbEmp.GetEmployees();
        }
        public bool UpdateEmployee(Employee empObj)
        {
            return dbEmp.UpdateEmployee(empObj);    
        }
        public bool DeleteEmployee(int empid)
        {
            return dbEmp.DeleteEmployee(empid);
        }
    }
}

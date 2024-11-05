using Microsoft.AspNetCore.Mvc;
using BusinessLayerBAL;
using BusinessLayerBAL.Contract;
using Microsoft.CodeAnalysis.Scripting;
using CommonLayer;

namespace ConnectNTierCore.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employee;
        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }
        public IActionResult Index()
        {
            var employee = _employee.GetEmployees();
            return View(employee);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee empObj)
        {
            bool b = _employee.AddEmployee(empObj);
            if (b != false)
            {
                TempData["insert"] = "<Script>alert('Employee Added SuccessFully!!');</Script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["insert"] = "<Script>alert('Employee Failed!!');</Script>";
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _employee.GetEmployee(id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(Employee empObj)
        {

            bool b = _employee.UpdateEmployee(empObj);
            if (b != false)
            {
                TempData["update"] = "<Script>alert('Employee Updated SuccessFully!!');</Script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["update"] = "<Script>alert('Employee Failed!!');</Script>";
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {

            bool b = _employee.DeleteEmployee(id);
            if (b != false)
            {
                TempData["delete"] = "<Script>alert('Employee Deleted SuccessFully!!');</Script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["delete"] = "<Script>alert('Employee Failed!!');</Script>";
            }
            return View();
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var employee = _employee.GetEmployee(id);
            return View(employee);
        }

    }
}

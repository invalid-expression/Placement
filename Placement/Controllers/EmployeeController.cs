using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Placement.Models;

namespace Placement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _employeeDbContext;
        private readonly INotyfService _notyf;
        public EmployeeController(EmployeeDbContext employeeDbContext, INotyfService notyfService)
        {
            _employeeDbContext = employeeDbContext;
            _notyf = notyfService;
        }
        
        public IActionResult Index()
        {
            _notyf.Information("Go To Homepage To Create Your New Account.", 10);
            var employee = _employeeDbContext.Employee.ToList();
            return View(employee);
        }

        public IActionResult CreateEmployee() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEmployee(Employee model)
        {
            if (ModelState.IsValid)
            {
                _employeeDbContext.Employee.Add(model);
                _employeeDbContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(model);
            }
               
        }

        public IActionResult UpdateEmployee(int ID)
        {
            if(ID != 0)
            {
                _notyf.Information("Edit Your Details Then Click on Confirm");
                var model = _employeeDbContext.Employee.FirstOrDefault(x => x.ID == ID);
                return View(model);
            }
            return View();
            
        }

        [HttpPost]
        public IActionResult UpdateEmployee(Employee updatemodel)
        {
            var old_student_entries = _employeeDbContext.Employee.FirstOrDefault(e => e.ID == updatemodel.ID);
            _employeeDbContext.Entry(old_student_entries).CurrentValues.SetValues(updatemodel);
            _employeeDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteEmployee(int ID)
        {
            var model = _employeeDbContext.Employee.FirstOrDefault(x => x.ID == ID);
            _employeeDbContext.Employee.Remove(model);
            _notyf.Custom("Account Has Been Deleted", 5,"red", "fa fa-trash");
            _employeeDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

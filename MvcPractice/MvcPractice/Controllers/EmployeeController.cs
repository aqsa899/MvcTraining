using Microsoft.AspNetCore.Mvc;
using MvcPractice.Models;
using System.Collections.Generic;
namespace MvcPractice.Controllers
{
    public class EmployeeController : Controller
    {
        private static List<Employee> employees = new List<Employee>
    {
        new Employee { Id = 1, Name = "Alice", Position = "Developer" },
        new Employee { Id = 2, Name = "Bob", Position = "Designer" },
        new Employee { Id = 3, Name = "Charlie", Position = "Manager" }
    };

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetEmployees()
        {
            return Json(employees);
        }
    }

}

using Microsoft.AspNetCore.Mvc;
using MvcPractice.Models;

namespace MvcPractice.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(User user)
        {
            return Content($"User: {user.Name}, Age: {user.Age}");
        }
    }
}

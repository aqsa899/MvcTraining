using Microsoft.AspNetCore.Mvc;
using MvcPractice.Models;

namespace MvcPractice.Controllers
{
   // [Route("shop")]
    public class ProductController : Controller
    {
        [Route("all")]
        public IActionResult List()
        {
            // ViewData["Title"] = "Product List";
            // return View();

            var product = new Product { Name = "Laptop", Price = 1200 };
            return View(product);
        }

        [Route("item/{id:int}")]
        public IActionResult Details(int id)
        {
            return Content($"Product Details for ID: {id}");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                return Content($"Product {product.Name} with price ${product.Price} added!");
            }
            return View(product);
        }

    }
}

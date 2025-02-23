using Microsoft.AspNetCore.Mvc;
using MvcPractice.Models;

namespace MvcPractice.Controllers
{
   // [Route("shop")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        // READ: Show all products
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
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
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // UPDATE: Show edit form
        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // UPDATE: Save changes
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        // 🔹 GET: Delete Confirmation Page
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        // 🔹 POST: Confirm Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index)); // Redirect to the list after delete
        }

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
    }
}

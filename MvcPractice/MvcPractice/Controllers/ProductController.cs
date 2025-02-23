using Microsoft.AspNetCore.Mvc;
using MvcPractice.Models;

namespace MvcPractice.Controllers
{
   // [Route("shop")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddProductAsync(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }      

        // UPDATE: Show edit form
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.FindProductAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // UPDATE: Save changes
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productService.EditProductAsync(product);
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

            var product = await _productService.FindProductAsync(id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        // 🔹 POST: Confirm Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var product = await _productService.FindProductAsync(id);
            if (product == null)
                return NotFound();

            await _productService.DeleteProductAsync(product);


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

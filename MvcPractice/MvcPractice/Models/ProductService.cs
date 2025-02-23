namespace MvcPractice.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
        
        public async Task EditProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
        
        public async Task DeleteProductAsync(Product product)
        {
            _context.Products.Remove(product!);
            await _context.SaveChangesAsync();
        }
        
        public async Task<Product?> FindProductAsync(int? id)
        {
            var product = await _context.Products.FindAsync(id);
            return product;
        }
    }

}

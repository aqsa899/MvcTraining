using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcPractice.Models
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task AddProductAsync(Product product);
        Task EditProductAsync(Product product);
        Task<Product?> FindProductAsync(int? id);
        Task DeleteProductAsync(Product prod);
    }

}

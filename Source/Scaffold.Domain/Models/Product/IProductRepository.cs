using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scaffold.Domain.Models.Product
{
    public interface IProductRepository
    {
        Task AddProduct(Product product);
        bool AlreadyExists(string sku);
        Task<Product> GetProduct(string sku);
        Task<IEnumerable<Product>> GetAllProducts();
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scaffold.Domain.Models.ProductModel.Repositories
{
    public interface IProductRepository
    {
        bool ExistsById(string id);
        bool ExistsBySku(string sku);
        Task<Product> GetById(string id);
        Task<Product> GetBySku(string sku);
        Task<IEnumerable<Product>> GetAll();
        Task Add(Product product);
        //Task Delete(string id);
    }
}

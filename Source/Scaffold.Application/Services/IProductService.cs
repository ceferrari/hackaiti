using Scaffold.Application.Results;
using Scaffold.Domain.Models.ProductModel;

namespace Scaffold.Application.Services
{
    public interface IProductService
    {
        AbstractApiResult GetAll();
        AbstractApiResult GetById(string id);
        AbstractApiResult GetBySku(string sku);
        AbstractApiResult Create(Product product);
    }
}

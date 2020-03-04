using Scaffold.Application.Results;
using Scaffold.Domain.Models.Product;

namespace Scaffold.Application.AppServices
{
    public interface IProductService
    {
        Result Get(object id);
        Result Create(Product product);
    }
}

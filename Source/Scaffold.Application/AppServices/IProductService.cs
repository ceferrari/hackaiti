using Scaffold.Application.Results;
using Scaffold.Domain.Models.Product;

namespace Scaffold.Application.AppServices
{
    public interface IProductService
    {
        Result Create(Product product);
    }
}

using Scaffold.Domain.Core.Bus;
using Scaffold.Domain.Models.Product;
using Scaffold.Domain.Models.Product.Commands;

namespace Scaffold.Application.AppServices
{
    public class ProductService : AbstractService
    {
        public ProductService(IBus bus)
            : base(bus)
        {

        }

        public Product Create(Product product)
        {
            var command = new ProductCreateCommand(product);
            return Bus.Submit(command).Data;
        }
    }
}

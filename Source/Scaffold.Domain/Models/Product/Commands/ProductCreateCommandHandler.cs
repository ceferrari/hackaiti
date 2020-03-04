using Scaffold.Domain.Core.Bus;
using Scaffold.Domain.Core.Commands;
using Scaffold.Domain.Core.Results;

namespace Scaffold.Domain.Models.Product.Commands
{
    public sealed class ProductCreateCommandHandler : CommandHandler<ProductCreateCommand, Product>
    {
        public ProductCreateCommandHandler(IBus bus)
            : base(bus)
        {

        }

        public override AbstractOperationResult<Product> Handle(ProductCreateCommand command)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return new FailureOperationResult<Product>("error creating product");
            }

            var entity = new Product(command.Id)
            {
                sku = command.sku,
                name = command.name,
                shortDescription = command.shortDescription,
                longDescription = command.longDescription,
                imageUrl = command.imageUrl
            };

            if (ProductRepository.Products.Exists(x => x.sku == command.sku))
            {
                return new FailureOperationResult<Product>("product with specified sku already exists");
            }

            ProductRepository.Products.Add(entity);

            //if (Commit())
            //{
            //    return new FailureOperationResult<Product>("error creating product");
            //}

            return new SuccessOperationResult<Product>("product created", entity);
        }
    }
}

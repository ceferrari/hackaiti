using Scaffold.Domain.Core.Bus;
using Scaffold.Domain.Core.Commands;
using Scaffold.Domain.Core.Repositories;
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
                return new FailureOperationResult<Product>("Error creating product");
            }

            var entity = new Product(command.Id)
            {
                SKU = command.SKU,
                Name = command.Name,
                ShortDescription = command.ShortDescription,
                LongDescription = command.LongDescription,
                ImageURL = command.ImageURL
            };

            ProductRepository.Products.Add(entity);

            //if (Commit())
            //{
            //    return new FailureOperationResult<Product>("Error creating product");
            //}

            return new SuccessOperationResult<Product>("Product created", entity);
        }
    }
}

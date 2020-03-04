using Scaffold.Domain.Core.Bus;
using Scaffold.Domain.Core.Commands;
using Scaffold.Domain.Core.Results;

namespace Scaffold.Domain.Models.Product.Commands
{
    public sealed class ProductCreateCommandHandler : CommandHandler<ProductCreateCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductCreateCommandHandler(IBus bus, IProductRepository productRepository)
            : base(bus)
        {
            _productRepository = productRepository;
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
                imageUrl = command.imageUrl,
                price = command.price
            };

            if (_productRepository.AlreadyExists(command.sku))
            {
                return new FailureOperationResult<Product>("product with specified sku already exists");
            }

            _productRepository.AddProduct(entity).Wait();

            var py = _productRepository.GetAllProducts().Result;

            var px = _productRepository.GetProduct(entity.sku).Result;

            //if (Commit())
            //{
            //    return new FailureOperationResult<Product>("error creating product");
            //}

            return new SuccessOperationResult<Product>("product created", entity);
        }
    }
}

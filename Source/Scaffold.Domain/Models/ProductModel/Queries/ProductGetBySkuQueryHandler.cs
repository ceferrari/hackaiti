using Scaffold.Domain.Core.Queries;
using Scaffold.Domain.Core.Results;
using Scaffold.Domain.Models.ProductModel.Repositories;

namespace Scaffold.Domain.Models.ProductModel.Queries
{
    public sealed class ProductGetBySkuQueryHandler : QueryHandler<ProductGetBySkuQuery, Product>
    {
        private readonly IProductRepository _repository;

        public ProductGetBySkuQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public override AbstractOperationResult<Product> Handle(ProductGetBySkuQuery query)
        {
            var result = _repository.GetBySku(query.Id.ToString()).Result;

            return new SuccessOperationResult<Product>(result);
        }
    }
}

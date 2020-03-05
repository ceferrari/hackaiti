using Scaffold.Domain.Core.Queries;
using Scaffold.Domain.Core.Results;
using Scaffold.Domain.Models.ProductModel.Repositories;

namespace Scaffold.Domain.Models.ProductModel.Queries
{
    public sealed class ProductGetByIdQueryHandler : QueryHandler<ProductGetByIdQuery, Product>
    {
        private readonly IProductRepository _repository;

        public ProductGetByIdQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public override AbstractOperationResult<Product> Handle(ProductGetByIdQuery query)
        {
            var result = _repository.GetById(query.Id.ToString()).Result;

            return new SuccessOperationResult<Product>(result);
        }
    }
}

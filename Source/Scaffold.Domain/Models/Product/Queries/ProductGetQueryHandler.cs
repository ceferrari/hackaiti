using Scaffold.Domain.Core.Queries;
using Scaffold.Domain.Core.Results;
using System.Collections.Generic;
using System.Linq;

namespace Scaffold.Domain.Models.Product.Queries
{
    public sealed class ProductGetQueryHandler : QueryHandler<ProductGetQuery, List<Product>>
    {
        private readonly IProductRepository _repository;

        public ProductGetQueryHandler(IProductRepository repository)
        {
            this._repository = repository;
        }

        public override AbstractOperationResult<List<Product>> Handle(ProductGetQuery query)
        {
            var result = _repository.GetAllProducts().Result.ToList();

            return new SuccessOperationResult<List<Product>>(result);
        }
    }
}

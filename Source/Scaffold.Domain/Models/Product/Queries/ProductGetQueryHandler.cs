using Scaffold.Domain.Core.Queries;
using Scaffold.Domain.Core.Results;
using System.Collections.Generic;

namespace Scaffold.Domain.Models.Product.Queries
{
    public sealed class ProductGetQueryHandler : QueryHandler<ProductGetQuery, List<Product>>
    {
        public override AbstractOperationResult<List<Product>> Handle(ProductGetQuery query)
        {
            var result = ProductRepository.Products;

            return new SuccessOperationResult<List<Product>>(result);
        }
    }
}

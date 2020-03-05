using Scaffold.Domain.Core.Queries;
using System.Collections.Generic;

namespace Scaffold.Domain.Models.ProductModel.Queries
{
    public sealed class ProductGetAllQuery : Query<Product, List<Product>>
    {
        public ProductGetAllQuery()
            : base(null)
        {

        }
    }
}

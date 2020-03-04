using Scaffold.Domain.Core.Queries;
using System.Collections.Generic;

namespace Scaffold.Domain.Models.Product.Queries
{
    public sealed class ProductGetQuery : Query<Product, List<Product>>
    {
        public ProductGetQuery(object id = null)
            : base(id)
        {

        }
    }
}

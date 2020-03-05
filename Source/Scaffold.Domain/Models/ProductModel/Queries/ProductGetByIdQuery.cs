using Scaffold.Domain.Core.Queries;

namespace Scaffold.Domain.Models.ProductModel.Queries
{
    public sealed class ProductGetByIdQuery : Query<Product, Product>
    {
        public ProductGetByIdQuery(string id)
            : base(id)
        {

        }
    }
}

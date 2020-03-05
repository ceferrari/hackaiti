using Scaffold.Domain.Core.Queries;

namespace Scaffold.Domain.Models.ProductModel.Queries
{
    public sealed class ProductGetBySkuQuery : Query<Product, Product>
    {
        public ProductGetBySkuQuery(string sku)
            : base(sku)
        {

        }
    }
}

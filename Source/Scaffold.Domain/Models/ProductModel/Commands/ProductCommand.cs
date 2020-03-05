using Scaffold.Domain.Core.Commands;
using System;
using System.Linq.Expressions;

namespace Scaffold.Domain.Models.ProductModel.Commands
{
    public abstract class ProductCommand : Command<Guid, Product, Product>
    {
        public string sku { get; }
        public string name { get; }
        public string shortDescription { get; }
        public string longDescription { get; }
        public string imageUrl { get; }
        public ProductPrice price { get; set; }

        protected readonly ProductValidator Validator;

        protected ProductCommand(Guid id, Expression<Func<Product, bool>> filter = null)
            : base(id, filter)
        {
            Validator = new ProductValidator();
        }

        protected ProductCommand(Product product)
            : this(Guid.NewGuid())
        {
            sku = product.sku;
            name = product.name;
            shortDescription = product.shortDescription;
            longDescription = product.longDescription;
            imageUrl = product.imageUrl;
            price = product.price;
        }
    }
}

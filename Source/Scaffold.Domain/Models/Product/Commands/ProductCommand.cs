using Scaffold.Domain.Core.Commands;
using System;
using System.Linq.Expressions;

namespace Scaffold.Domain.Models.Product.Commands
{
    public abstract class ProductCommand : Command<Guid, Product, Product>
    {
        public string SKU { get; }
        public string Name { get; }
        public string ShortDescription { get; }
        public string LongDescription { get; }
        public string ImageURL { get; }

        protected readonly ProductValidator Validator;

        protected ProductCommand(Guid id, Expression<Func<Product, bool>> filter = null)
            : base(id, filter)
        {
            Validator = new ProductValidator();
        }

        protected ProductCommand(Product product)
            : this(product.Id)
        {
            SKU = product.SKU;
            Name = product.Name;
            ShortDescription = product.ShortDescription;
            LongDescription = product.LongDescription;
            ImageURL = product.ImageURL;
        }
    }
}

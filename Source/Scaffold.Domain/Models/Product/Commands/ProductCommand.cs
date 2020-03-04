using Scaffold.Domain.Core.Commands;
using System;
using System.Linq.Expressions;

namespace Scaffold.Domain.Models.Product.Commands
{
    public abstract class ProductCommand : Command<int, Product, Product>
    {
        public string SKU { get; }
        public string Name { get; }
        public string ShortDescription { get; }
        public string LongDescription { get; }
        public string ImageURL { get; }

        protected readonly ProductValidator Validator;

        protected ProductCommand(int id, Expression<Func<Product, bool>> filter = null)
            : base(id, filter)
        {
            Validator = new ProductValidator();
        }

        protected ProductCommand(int id, Product product)
            : this(id)
        {
            SKU = product.SKU;
            Name = product.Name;
            ShortDescription = product.ShortDescription;
            LongDescription = product.LongDescription;
            ImageURL = product.ImageURL;
        }
    }
}

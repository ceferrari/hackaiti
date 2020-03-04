using Scaffold.Domain.Core.Entities;
using System;

namespace Scaffold.Domain.Models.Product
{
    public class Product : Entity<Guid>
    {
        public Product()
        {
            price = new ProductPrice();
        }

        public Product(Guid id)
            : base(id)
        {
            price = new ProductPrice();
        }

        public string sku { get; set; }
        public string name { get; set; }
        public string shortDescription { get; set; }
        public string longDescription { get; set; }
        public string imageUrl { get; set; }
        public ProductPrice price { get; set; }
    }
}

using Scaffold.Domain.Core.Entities;
using System;

namespace Scaffold.Domain.Models.Cart
{
    public class CartItem : Entity<Guid>
    {
        public long? price { get; set; }
        public long? scale { get; set; }
        public string curencyCode { get; set; }
    }

    public class CartCreateItem
    {
        public string sku { get; set; }
        public long? quantity { get; set; }
    }
}

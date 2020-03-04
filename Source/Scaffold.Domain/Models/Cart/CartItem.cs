using Scaffold.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scaffold.Domain.Models.Cart
{
    public class CartItem : Entity<Guid>
    {
        public long price { get; set; }
        public long scale { get; set; }
        public string curencyCode { get; set; }
    }

    public class CartCommandItem
    {
        public string sku { get; set; }
        public long quantity { get; set; }
    }
}

using Scaffold.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scaffold.Domain.Models.Cart
{
    public class Cart : Entity<Guid>
    {
        public string customerId { get; set; }
        public string status { get; set; }
        public List<CartItem> items { get; set; }
    }

    public class CartCreate : Entity<Guid>
    {
        public string sku { get; set; }
        public CartItem item { get; set; }
    }
}

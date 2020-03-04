using Scaffold.Domain.Core.Entities;

namespace Scaffold.Domain.Models.Product
{
    public class Product : Entity<int>
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string ImageURL { get; set; }
        public ProductPrice Price { get; set; }
    }
}

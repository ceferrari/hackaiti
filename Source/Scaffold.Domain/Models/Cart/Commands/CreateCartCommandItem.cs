namespace Scaffold.Domain.Models.Cart.Commands
{
    public class CreateCartCommandItem
    {
        public string SKU { get; set; }
        public long Quantity { get; set; }
    }
}

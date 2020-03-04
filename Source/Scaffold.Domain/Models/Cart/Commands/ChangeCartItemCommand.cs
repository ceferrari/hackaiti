namespace Scaffold.Domain.Models.Cart.Commands
{
    public class ChangeCartItemCommand
    {
        public string CartId { get; set; }
        public string SKU { get; set; }
        public long Quantity { get; set; }
    }
}
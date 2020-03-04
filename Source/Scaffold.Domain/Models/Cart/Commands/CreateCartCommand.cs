namespace Scaffold.Domain.Models.Cart.Commands
{
    public class CreateCartCommand
    {
        public string CustomerId { get; set; }
        public CreateCartCommandItem Item { get; set; }
    }
}
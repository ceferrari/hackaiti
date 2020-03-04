namespace Scaffold.Domain.Models.Cart.Commands
{
    public class CreateCartCommandResponseItem
    {
        public long Id { get; set; }
        public decimal Price { get; set; }
        public long Scale { get; set; }
        public string CurrencyCode { get; set; }
    }
}
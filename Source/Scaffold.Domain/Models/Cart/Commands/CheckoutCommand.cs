namespace Scaffold.Domain.Models.Cart.Commands
{
    public class CheckoutCommand
    {
        public string CartId { get; set; }
        public string CurrencyCode { get; set; }
        public string TeamControlId { get; set; }
    }
}
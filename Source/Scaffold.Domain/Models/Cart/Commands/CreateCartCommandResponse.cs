using System.Collections.Generic;

namespace Scaffold.Domain.Models.Cart.Commands
{
    public class CreateCartCommandResponse
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string Status { get; set; }
        public IEnumerable<CreateCartCommandResponseItem> Items { get; set; }
    }
}
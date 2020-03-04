using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scaffold.Domain.Models.Cart
{
    public interface ICartRepository
    {
        Task AddCart(Cart cart);
        bool AlreadyExists(string sku);
        Task<Cart> GetCart(string sku);
        Task<IEnumerable<Cart>> GetAllCarts();
    }
}

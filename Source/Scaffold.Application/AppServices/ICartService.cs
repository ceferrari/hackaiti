using Scaffold.Application.Results;
using Scaffold.Domain.Models.Cart;
using System;

namespace Scaffold.Application.AppServices
{
    public interface ICartService
    {
        Result Get(object id);
        Result Create(Cart cart);
        Result Delete(Guid id);
    }
}

using Scaffold.Application.Results;
using Scaffold.Domain.Models.CartModel;

namespace Scaffold.Application.Services
{
    public interface ICartService
    {
        AbstractApiResult GetAll();
        AbstractApiResult GetById(string id);
        AbstractApiResult GetByCustomerId(string id);
        AbstractApiResult Create(Cart cart);
        AbstractApiResult Delete(string id);
        AbstractApiResult Update(string id, CartEditItem item);
    }
}

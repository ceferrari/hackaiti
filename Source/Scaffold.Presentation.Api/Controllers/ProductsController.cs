using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Scaffold.Domain.Core.Bus;
using Scaffold.Domain.Models.Product;

namespace Scaffold.Presentation.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")] 
    public class ProductsController : ControllerBase
    {
        private readonly IBus _bus;

        public ProductsController(IBus bus)
        {
            _bus = bus;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return new Product[0];
        }

        [HttpPost]
        public Product Post([FromBody]Product product)
        {
            var command = mapper.Map<ProductreateCommand>(product);
            return bus.Submit(command).Data;
        }

       
    }
}

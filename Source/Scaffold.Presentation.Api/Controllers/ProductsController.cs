using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Scaffold.Application.AppServices;
using Scaffold.Domain.Core.Bus;
using Scaffold.Domain.Models.Product;
using Scaffold.Domain.Models.Product.Commands;

namespace Scaffold.Presentation.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")] 
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return new Product[0];
        }

        [HttpPost]
        public Product Post([FromBody]Product product)
        {
            return _productService.Create(product);
        }
    }
}

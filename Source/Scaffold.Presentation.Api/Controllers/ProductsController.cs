using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Scaffold.Application.AppServices;
using Scaffold.Application.Results;
using Scaffold.Domain.Models.Product;

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
        public IActionResult Post([FromBody]Product product)
        {
            return _productService.Create(product);
        }
    }
}

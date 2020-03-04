using Microsoft.AspNetCore.Mvc;
using Scaffold.Application.AppServices;
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
        public IActionResult Get([FromRoute]string id)
        {
            return _productService.Get(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            return _productService.Create(product);
        }
    }
}

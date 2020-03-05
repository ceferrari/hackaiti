using Microsoft.AspNetCore.Mvc;
using Scaffold.Application.Services;
using Scaffold.Domain.Models.ProductModel;

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
        public IActionResult Get([FromRoute]string id, [FromQuery]string sku)
        {
            if (id == null && sku == null) 
                return _productService.GetAll();

            if (id == null) 
                return _productService.GetBySku(sku);
            else
                return _productService.GetById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            return _productService.Create(product);
        }
    }
}

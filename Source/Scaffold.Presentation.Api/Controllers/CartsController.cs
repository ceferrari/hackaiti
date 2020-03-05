using Microsoft.AspNetCore.Mvc;
using Scaffold.Application.Services;
using Scaffold.Domain.Models.CartModel;

namespace Scaffold.Presentation.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public IActionResult Get([FromRoute]string id, [FromQuery]string customerId)
        {
            if (id == null && customerId == null)
                return _cartService.GetAll();

            if (id == null)
                return _cartService.GetByCustomerId(customerId);
            else
                return _cartService.GetById(id);
        }

        [HttpPost("")]
        public IActionResult Post([FromBody]Cart cart)
        {
            return _cartService.Create(cart);
        }

        [HttpPatch]
        [Route("{id}/items")]
        public IActionResult Patch([FromRoute]string id, [FromBody]CartEditItem item)
        {
            return _cartService.Update(id, item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return _cartService.Delete(id);
        }

        //[HttpPost]
        //[Route("{id}/checkout")]
        //public IActionResult Checkout([FromRoute]string id, [FromBody]CheckoutCommand checkoutCommand)
        //{
        //    var teamControlId = Request.Headers["x-team-control"].FirstOrDefault();            

        //    if (string.IsNullOrWhiteSpace(teamControlId)) return BadRequest();

        //    if (string.IsNullOrWhiteSpace(id)) return BadRequest();

        //    if (checkoutCommand == null) return BadRequest();

        //    checkoutCommand.CartId = id;
        //    checkoutCommand.TeamControlId = teamControlId;

        //    return Ok();
        //}
    }
}

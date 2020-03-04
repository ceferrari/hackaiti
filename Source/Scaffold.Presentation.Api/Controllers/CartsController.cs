using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Scaffold.Application.AppServices;
using Scaffold.Domain.Models.Cart;
using Scaffold.Domain.Models.Cart.Commands;

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

        [HttpPost("")]
        public IActionResult CartPost([FromBody]Cart cart)
        {
            return _cartService.Create(cart);
        }

        [HttpDelete("{id}")]
        public IActionResult CartDelete(Guid id)
        {
            return _cartService.Delete(id);
        }

        //[HttpPatch]
        //[Route("{id}/items")]
        //public IActionResult CartPatch([FromRoute]string id, [FromBody]ChangeCartItemCommand patchCommand)
        //{
        //    if (string.IsNullOrWhiteSpace(id)) return BadRequest();

        //    if (patchCommand == null) return BadRequest();

        //    patchCommand.CartId = id;

        //    return Ok(new CreateCartCommandResponse());
        //}

        //[HttpPost]
        //[Route("{id}/checkout")]
        //public IActionResult CheckoutPost([FromRoute]string id, [FromBody]CheckoutCommand checkoutCommand)
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

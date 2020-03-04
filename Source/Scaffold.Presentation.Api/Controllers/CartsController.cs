using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Scaffold.Domain.Models.Cart.Commands;

namespace Scaffold.Presentation.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class CartsController : ControllerBase
    {
        private readonly ILogger<CartsController> _logger;

        public CartsController(ILogger<CartsController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public CreateCartCommandResponse CartPost([FromBody]CreateCartCommand createCommand)
        {
            return new CreateCartCommandResponse();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult CartDelete(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return BadRequest();

            var deleteCommand = new DeleteCommand()
            {
                CartId = id
            };

            return Ok();
        }

        [HttpPatch]
        [Route("{id}/items")]
        public IActionResult CartPatch([FromRoute]string id, [FromBody]ChangeCartItemCommand patchCommand)
        {
            if (string.IsNullOrWhiteSpace(id)) return BadRequest();

            if (patchCommand == null) return BadRequest();

            patchCommand.CartId = id;

            return Ok(new CreateCartCommandResponse());
        }

        [HttpPost]
        [Route("{id}/checkout")]
        public IActionResult CheckoutPost([FromRoute]string id, [FromBody]CheckoutCommand checkoutCommand)
        {
            var teamControlId = Request.Headers["x-team-control"].FirstOrDefault();            

            if (string.IsNullOrWhiteSpace(teamControlId)) return BadRequest();

            if (string.IsNullOrWhiteSpace(id)) return BadRequest();

            if (checkoutCommand == null) return BadRequest();

            checkoutCommand.CartId = id;
            checkoutCommand.TeamControlId = teamControlId;

            return Ok();
        }

    }
}

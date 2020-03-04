using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Scaffold.Domain.Models;
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
        public CreateCartCommandResponse Post([FromBody]CreateCartCommand createCommand)
        {
            return new CreateCartCommandResponse();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok();
        }

        [HttpPatch]
        [Route("{id}/items")]
        public CreateCartCommandResponse Patch([FromRoute]string id, [FromBody]ChangeCartItemCommand createCommand)
        {
            return new CreateCartCommandResponse();
        }
    }
}

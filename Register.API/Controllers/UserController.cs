using FluentResults.Extensions.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Register.Application;

namespace Register.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = new ListUserRequest();

            var result = await _mediator.Send(users).ToActionResult();

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] long id)
        {
            var user = new GetUserRequest(id);

            var result = await _mediator.Send(user).ToActionResult();

            return Ok(result);
        }
    }
}

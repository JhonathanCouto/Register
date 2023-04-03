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

            var result = await _mediator.Send(users);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] long id)
        {
            var user = new GetUserRequest(id);

            var result = await _mediator.Send(user);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddUserRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(UpdateUserRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {

            var result = await _mediator.Send(new DeleteUserRequest(id));

            return Ok(result);
        }
    }
}

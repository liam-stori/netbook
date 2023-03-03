using NetBook.Application.Commands.CreateUser;
using NetBook.Application.Commands.DeleteUser;
using NetBook.Application.Commands.EnableUser;
using NetBook.Application.Commands.LoginUser;
using NetBook.Application.Commands.UpdateUser;
using NetBook.Application.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace NetBook.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Users")]
        public async Task<IActionResult> GetById(int id)
        {
            var command = new GetUserByIdQuery(id);

            var user = await _mediator.Send(command);

            if (user == null) return NotFound();           

            return Ok(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var loginUserViewModel = await _mediator.Send(command);

            if (loginUserViewModel == null) return BadRequest();

            return Ok(loginUserViewModel);
        }

        [HttpPut("{id}/update")]
        [Authorize(Roles = "Users")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateUserCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/disable")]
        [Authorize(Roles = "Users")]
        public async Task<IActionResult> Disable(int id)
        {
            var command = new DisableUserCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/enable")]
        [AllowAnonymous]
        public async Task<IActionResult> Enable(int id)
        {
            var command = new EnableUserCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}

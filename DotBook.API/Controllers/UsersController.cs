using DotBook.Application.Commands.CreateUser;
using DotBook.Application.Commands.DeleteUser;
using DotBook.Application.Commands.EnableUser;
using DotBook.Application.Commands.LoginUser;
using DotBook.Application.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DotBook.API.Controllers
{
    [Route("api/users")]
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

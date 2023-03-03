using NetBook.Application.Commands.CreateComment;
using NetBook.Application.Commands.DeleteComment;
using NetBook.Application.Commands.UpdateComment;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace NetBook.API.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "Users")]
        public async Task<IActionResult> Post([FromBody] CreateCommentCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Users")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateCommentCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}/publication")]
        [Authorize(Roles = "Users")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCommentCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}

using DotBook.Application.Commands.CreateComment;
using DotBook.Application.Commands.DeleteComment;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DotBook.API.Controllers
{
    [Route("api/comments")]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "Users")]
        public async Task<IActionResult> PostComment([FromBody] CreateCommentCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}/publication")]
        [Authorize(Roles = "Users")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var command = new DeleteCommentCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}

using DotBook.Application.Commands.CreateComment;
using DotBook.Application.Commands.CreatePublication;
using DotBook.Application.Queries.GetAllPublication;
using DotBook.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DotBook.API.Controllers
{
    [Route("api/publications")]
    public class PublicationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PublicationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getAllPublicationQuery = new GetAllPublicationQuery();

            var publications = await _mediator.Send(getAllPublicationQuery);

            if (publications is null) return NotFound();

            return Ok(publications);
        }

        [HttpGet("publicationUser/{id}")]
        public async Task<IActionResult> GetById(int idUser)
        {
            var getAllPublicationByUserQuery = new GetAllPublicationByUserQuery(idUser);

            var publicationsByUser = await _mediator.Send(getAllPublicationByUserQuery);

            if (publicationsByUser is null) return NotFound();

            return Ok(publicationsByUser);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePublicationCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment([FromBody] CreateCommentCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}

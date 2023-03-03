using AutoMapper;
using NetBook.Application.Commands.CreatePublication;
using NetBook.Application.Commands.DeletePublication;
using NetBook.Application.Commands.UpdatePublication;
using NetBook.Application.Queries.GetAllPublication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace NetBook.API.Controllers
{
    [Route("api/publications")]
    [ApiController]
    public class PublicationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PublicationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "Users")]
        public async Task<IActionResult> Get()
        {
            var getAllPublicationQuery = new GetAllPublicationQuery();

            var publications = await _mediator.Send(getAllPublicationQuery);

            if (publications is null) return NotFound();

            return Ok(publications);
        }

        [HttpGet("{userId}")]
        [Authorize(Roles = "Users")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var getAllPublicationByUserQuery = new GetAllPublicationByUserQuery(userId);

            var publicationsByUser = await _mediator.Send(getAllPublicationByUserQuery);

            if (publicationsByUser is null) return NotFound();

            return Ok(publicationsByUser);
        }

        [HttpPost]
        [Authorize(Roles = "Users")]
        public async Task<IActionResult> Post([FromBody] CreatePublicationCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetByUserId), new { userId = id }, command);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Users")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdatePublicationCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Users")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeletePublicationCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }        
    }
}

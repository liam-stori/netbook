using AutoMapper;
using DotBook.Application.Commands.CreatePublication;
using DotBook.Application.Commands.DeletePublication;
using DotBook.Application.Queries.GetAllPublication;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DotBook.API.Controllers
{
    [Route("api/publications")]
    public class PublicationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public PublicationsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getAllPublicationQuery = new GetAllPublicationQuery();

            var publications = await _mediator.Send(getAllPublicationQuery);

            if (publications is null) return NotFound();

            return Ok(publications);
        }

        [HttpGet("{userid}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var getAllPublicationByUserQuery = new GetAllPublicationByUserQuery(userId);

            var publicationsByUser = await _mediator.Send(getAllPublicationByUserQuery);

            if (publicationsByUser is null) return NotFound();

            return Ok(publicationsByUser);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePublicationCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetByUserId), new { id }, command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeletePublicationCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }        
    }
}

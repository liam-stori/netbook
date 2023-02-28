using AutoMapper;
using DotBook.Application.Commands.CreateComment;
using DotBook.Application.Commands.CreatePublication;
using DotBook.Application.Queries.GetAllPublication;
using DotBook.Core.DTOs;
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

        [HttpGet("userid")]
        public async Task<IActionResult> GetById(int userId)
        {
            var getAllPublicationByUserQuery = new GetAllPublicationByUserQuery(userId);

            var publicationsByUser = await _mediator.Send(getAllPublicationByUserQuery);

            if (publicationsByUser is null) return NotFound();

            //var map = _mapper.Map<PublicationCommentDTO>(publicationsByUser);
            //arrumar o mapeamento do AutoMapper
            return Ok(publicationsByUser);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePublicationCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPost("comments")]
        public async Task<IActionResult> PostComment([FromBody] CreateCommentCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}

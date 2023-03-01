using DotBook.Core.DTOs;
using DotBook.Core.Repositories;
using MediatR;

namespace DotBook.Application.Queries.GetAllPublication
{
    public class GetAllPublicationQueryHandler : IRequestHandler<GetAllPublicationQuery, List<PublicationDTO>>
    {
        private readonly IPublicationRepository _publicationRepository;
        public GetAllPublicationQueryHandler(IPublicationRepository publicationRepository)
        {
            _publicationRepository = publicationRepository;
        }

        public async Task<List<PublicationDTO>> Handle(GetAllPublicationQuery request, CancellationToken cancellationToken)
        {
            var publication = await _publicationRepository.GetAllAsync();

            if (publication == null) return null;

            return publication;
        }
    }
}

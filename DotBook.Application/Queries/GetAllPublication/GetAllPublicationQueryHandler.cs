using NetBook.Core.DTOs;
using NetBook.Core.Repositories;
using MediatR;

namespace NetBook.Application.Queries.GetAllPublication
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

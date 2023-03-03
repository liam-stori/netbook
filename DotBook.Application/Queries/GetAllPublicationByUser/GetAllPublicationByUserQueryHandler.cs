using NetBook.Core.DTOs;
using NetBook.Core.Repositories;
using MediatR;

namespace NetBook.Application.Queries.GetAllPublication
{
    public class GetAllPublicationByUserQueryHandler : IRequestHandler<GetAllPublicationByUserQuery, IEnumerable<PublicationDTO>>
    {
        private readonly IPublicationRepository _publicationRepository;
        public GetAllPublicationByUserQueryHandler(IPublicationRepository publicationRepository)
        {
            _publicationRepository = publicationRepository;
        }

        public async Task<IEnumerable<PublicationDTO>> Handle(GetAllPublicationByUserQuery request, CancellationToken cancellationToken)
        {
            var publications = await _publicationRepository.GetAllByUserIdAsync(request.UserId);

            if (publications == null) return null;

            return publications;
        }
    }
}

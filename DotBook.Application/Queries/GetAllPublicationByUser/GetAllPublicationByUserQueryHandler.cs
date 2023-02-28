using DotBook.Application.ViewModels;
using DotBook.Core.DTOs;
using DotBook.Core.Repositories;
using MediatR;
using System.Linq;

namespace DotBook.Application.Queries.GetAllPublication
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

            return publications;
        }
    }
}

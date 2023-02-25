using DotBook.Application.ViewModels;
using DotBook.Core.Repositories;
using MediatR;
using System.Linq;

namespace DotBook.Application.Queries.GetAllPublication
{
    public class GetAllPublicationByUserQueryHandler : IRequestHandler<GetAllPublicationByUserQuery, List<PublicationViewModel>>
    {
        private readonly IPublicationRepository _publicationRepository;
        public GetAllPublicationByUserQueryHandler(IPublicationRepository publicationRepository)
        {
            _publicationRepository = publicationRepository;
        }

        public async Task<List<PublicationViewModel>> Handle(GetAllPublicationByUserQuery request, CancellationToken cancellationToken)
        {
            var publication = await _publicationRepository.GetAllAsync();

            var publicationViewModel = publication
                .Where(p => p.IdUser == request.IdUser)
                .Select(p => new PublicationViewModel(p.Content, p.CreatedAt, p.IdUser, p.Comments))
                .ToList();

            return publicationViewModel;
        }
    }
}

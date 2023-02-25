using DotBook.Application.ViewModels;
using DotBook.Core.Repositories;
using MediatR;

namespace DotBook.Application.Queries.GetAllPublication
{
    public class GetAllPublicationQueryHandler : IRequestHandler<GetAllPublicationQuery, List<PublicationViewModel>>
    {
        private readonly IPublicationRepository _publicationRepository;
        public GetAllPublicationQueryHandler(IPublicationRepository publicationRepository)
        {
            _publicationRepository = publicationRepository;
        }

        public async Task<List<PublicationViewModel>> Handle(GetAllPublicationQuery request, CancellationToken cancellationToken)
        {
            var publication = await _publicationRepository.GetAllAsync();

            var publicationViewModel = publication
                .Select(p => new PublicationViewModel(
                    p.Content,
                    p.CreatedAt,
                    p.IdUser,
                    p.Comments))
                .ToList();

            return publicationViewModel;
        }
    }
}

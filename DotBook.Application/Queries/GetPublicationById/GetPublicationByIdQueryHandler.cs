using DotBook.Application.ViewModels;
using DotBook.Core.Repositories;
using MediatR;

namespace DotBook.Application.Queries.GetPublicationById
{
    public class GetPublicationByIdQueryHandler : IRequestHandler<GetPublicationByIdQuery, PublicationViewModel>
    {
        private readonly IPublicationRepository _publicationRepository;
        public GetPublicationByIdQueryHandler(IPublicationRepository publicationRepository)
        {
            _publicationRepository = publicationRepository;
        }

        public async Task<PublicationViewModel> Handle(GetPublicationByIdQuery request, CancellationToken cancellationToken)
        {
            var publication = await _publicationRepository.GetByIdAsync(request.Id);

            if (publication == null) return null;

            return new PublicationViewModel(
                publication.Content,
                publication.CreatedAt,
                publication.UserId,
                publication.Comments
                );
        }
    }
}

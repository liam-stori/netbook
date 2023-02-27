using DotBook.Application.ViewModels;
using DotBook.Core.Repositories;
using MediatR;
using System.Linq;

namespace DotBook.Application.Queries.GetAllPublication
{
    public class GetAllPublicationByUserQueryHandler : IRequestHandler<GetAllPublicationByUserQuery, List<PublicationUserViewModel>>
    {
        private readonly IPublicationRepository _publicationRepository;
        public GetAllPublicationByUserQueryHandler(IPublicationRepository publicationRepository)
        {
            _publicationRepository = publicationRepository;
        }

        public async Task<List<PublicationUserViewModel>> Handle(GetAllPublicationByUserQuery request, CancellationToken cancellationToken)
        {
            var publication = await _publicationRepository.GetAllByUserIdAsync(request.UserId);

            var publicationUserViewModel = publication
                .Select(p => new PublicationUserViewModel(
                    p.Content, 
                    p.CreatedAt, 
                    p.User.FirstName, 
                    p.Comments))
                .ToList();

            return publicationUserViewModel;
        }
    }
}

using DotBook.Application.ViewModels;
using DotBook.Core.Repositories;
using MediatR;

namespace DotBook.Application.Queries.GetAllComment
{
    public class GetAllCommentQueryHandler : IRequestHandler<GetAllCommentQuery, List<CommentViewModel>>
    {
        private readonly IPublicationRepository _publicationRepository;
        public GetAllCommentQueryHandler(IPublicationRepository publicationRepository)
        {
            _publicationRepository = publicationRepository;
        }

        public async Task<List<CommentViewModel>> Handle(GetAllCommentQuery request, CancellationToken cancellationToken)
        {
            var publication = await _publicationRepository.GetByIdAsync(request.IdPublication);
            var comments = await _publicationRepository.GetAllCommentsAsync();
        }
    }
}

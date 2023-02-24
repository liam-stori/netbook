using DotBook.Core.Entities;
using DotBook.Core.Repositories;
using MediatR;

namespace DotBook.Application.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly IPublicationRepository _publicationRepository;
        public CreateCommentCommandHandler(IPublicationRepository publicationRepository)
        {
            _publicationRepository = publicationRepository;
        }

        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new PublicationComment(request.Content, DateTime.Now, request.IdUser, request.IdPublication);

            await _publicationRepository.AddCommentAsync(comment);

            await _publicationRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

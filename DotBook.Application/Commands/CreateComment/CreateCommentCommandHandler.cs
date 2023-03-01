using DotBook.Core.Entities;
using DotBook.Core.Repositories;
using MediatR;

namespace DotBook.Application.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly ICommentRepository _commentRepository;
        public CreateCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new Comment(request.Content, request.UserId, request.PublicationId);

            await _commentRepository.AddAsync(comment);

            await _commentRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

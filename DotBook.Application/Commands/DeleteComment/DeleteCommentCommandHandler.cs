using DotBook.Core.Repositories;
using MediatR;

namespace DotBook.Application.Commands.DeleteComment
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, Unit>
    {
        private readonly ICommentRepository _commentRepository;
        public DeleteCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetByIdAsync(request.Id);

            comment.Disabled();

            await _commentRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

using DotBook.Core.Repositories;
using MediatR;

namespace DotBook.Application.Commands.UpdateComment
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Unit>
    {
        private readonly ICommentRepository _commentRepository;
        public UpdateCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetByIdAsync(request.Id);

            comment.Update(request.Content);

            await _commentRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

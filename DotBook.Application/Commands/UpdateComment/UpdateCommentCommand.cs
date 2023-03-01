using MediatR;

namespace DotBook.Application.Commands.UpdateComment
{
    public class UpdateCommentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Content { get; set; }
    }
}

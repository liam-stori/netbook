using MediatR;

namespace NetBook.Application.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<Unit>
    {
        public string Content { get; set; }
        public int UserId { get; set; }
        public int PublicationId { get; set; }
    }
}

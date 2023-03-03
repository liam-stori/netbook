using MediatR;

namespace NetBook.Application.Commands.DeleteComment
{
    public class DeleteCommentCommand : IRequest<Unit>
    {
        public DeleteCommentCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

using MediatR;

namespace DotBook.Application.Commands.UpdateComment
{
    public class UpdateCommentCommand : IRequest<Unit>
    {
        public UpdateCommentCommand(int id, string content)
        {
            Id = id;
            Content = content;
        }

        public int Id { get; set; }
        public string Content { get; set; }
    }
}

using MediatR;

namespace DotBook.Application.Commands.UpdatePublication
{
    public class UpdatePublicationCommand : IRequest<Unit>
    {
        public UpdatePublicationCommand(int id, string content)
        {
            Id = id;
            Content = content;
        }

        public int Id { get; set; }
        public string Content { get; set; }
    }
}

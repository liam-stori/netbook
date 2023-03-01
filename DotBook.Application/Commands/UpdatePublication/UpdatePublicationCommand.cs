using MediatR;

namespace DotBook.Application.Commands.UpdatePublication
{
    public class UpdatePublicationCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Content { get; set; }
    }
}

using MediatR;

namespace DotBook.Application.Commands.CreatePublication
{
    public class CreatePublicationCommand : IRequest<int>
    {
        public string Content { get; set; }
        public int IdUser { get; set; }
    }
}

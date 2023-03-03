using MediatR;

namespace NetBook.Application.Commands.CreatePublication
{
    public class CreatePublicationCommand : IRequest<int>
    {
        public string Content { get; set; }
        public int IdUser { get; set; }
    }
}

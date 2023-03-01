using MediatR;

namespace DotBook.Application.Commands.DeletePublication
{
    public class DeletePublicationCommand : IRequest<Unit>
    {
        public DeletePublicationCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }

    }
}

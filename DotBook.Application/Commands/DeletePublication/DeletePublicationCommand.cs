using MediatR;

namespace NetBook.Application.Commands.DeletePublication
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

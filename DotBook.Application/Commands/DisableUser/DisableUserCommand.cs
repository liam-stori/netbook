using MediatR;

namespace DotBook.Application.Commands.DeleteUser
{
    public class DisableUserCommand : IRequest<Unit>
    {
        public DisableUserCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}

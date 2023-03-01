using MediatR;

namespace DotBook.Application.Commands.EnableUser
{
    public class EnableUserCommand : IRequest<Unit>
    {
        public EnableUserCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}

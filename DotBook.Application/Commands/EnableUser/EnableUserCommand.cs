using MediatR;

namespace NetBook.Application.Commands.EnableUser
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

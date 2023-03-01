using MediatR;

namespace DotBook.Application.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
    }
}

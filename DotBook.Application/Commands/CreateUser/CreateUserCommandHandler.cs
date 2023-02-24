using DotBook.Core.Entities;
using DotBook.Core.Repositories;
using MediatR;

namespace DotBook.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.FirstName, request.LastName, request.BirthDate, request.PhoneNumber, request.Email, request.Password);

            await _userRepository.AddAsync(user);

            await _userRepository.SaveChangesAsync();

            return user.Id;
        }
    }
}

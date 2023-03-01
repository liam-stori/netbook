using DotBook.Application.Services;
using DotBook.Core.Entities;
using DotBook.Core.Repositories;
using MediatR;

namespace DotBook.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        public CreateUserCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = new User(request.FirstName, request.LastName, request.BirthDate, request.PhoneNumber, request.Email, passwordHash, request.Role);

            await _userRepository.AddAsync(user);

            await _userRepository.SaveChangesAsync();

            return user.Id;
        }
    }
}

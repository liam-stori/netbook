using NetBook.Application.Services;
using NetBook.Application.ViewModels;
using NetBook.Core.Repositories;
using MediatR;

namespace NetBook.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        public LoginUserCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = await _userRepository.GetByEmailAndPasswordAsync(request.Email, passwordHash);
            if (user == null) return null;

            var token = _authService.GenerateJwtToken(user.Email, user.Role);

            return new LoginUserViewModel(request.Email, token);
        }
    }
}

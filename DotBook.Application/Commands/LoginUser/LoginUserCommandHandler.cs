using DotBook.Application.ViewModels;
using DotBook.Core.Repositories;
using MediatR;

namespace DotBook.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IUserRepository _userRepository;
        public LoginUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAndPasswordAsync(request.Email, request.Password);

            if (user == null) return null;

            return new LoginUserViewModel(request.Email, request.Password);
        }
    }
}

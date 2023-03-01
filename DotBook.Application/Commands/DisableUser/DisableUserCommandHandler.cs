using DotBook.Core.Repositories;
using MediatR;

namespace DotBook.Application.Commands.DeleteUser
{
    public class DisableUserCommandHandler : IRequestHandler<DisableUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        public DisableUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DisableUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            user.DisabledAccount();

            await _userRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

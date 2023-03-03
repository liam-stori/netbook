using NetBook.Core.Repositories;
using MediatR;

namespace NetBook.Application.Commands.EnableUser
{
    public class EnableUserCommandHandler : IRequestHandler<EnableUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        public EnableUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(EnableUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            user.EnableAccount();

            await _userRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

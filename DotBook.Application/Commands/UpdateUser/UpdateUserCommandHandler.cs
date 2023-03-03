using NetBook.Core.Repositories;
using MediatR;

namespace NetBook.Application.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            user.Update(request.FirstName, request.LastName, request.BirthDate, request.PhoneNumber);

            await _userRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

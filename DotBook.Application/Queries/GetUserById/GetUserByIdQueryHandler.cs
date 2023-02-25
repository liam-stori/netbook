using DotBook.Application.ViewModels;
using DotBook.Core.Repositories;
using MediatR;

namespace DotBook.Application.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null) return null;
            
            return new UserViewModel(user.FirstName, user.LastName, user.BirthDate, user.PhoneNumber, user.Email);
        }
    }
}

using NetBook.Application.ViewModels;
using MediatR;

namespace NetBook.Application.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserViewModel>
    {
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}

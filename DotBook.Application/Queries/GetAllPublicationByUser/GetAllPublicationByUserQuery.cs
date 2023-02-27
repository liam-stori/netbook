using DotBook.Application.ViewModels;
using MediatR;

namespace DotBook.Application.Queries.GetAllPublication
{
    public class GetAllPublicationByUserQuery : IRequest<List<PublicationUserViewModel>>
    {
        public GetAllPublicationByUserQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; private set; }
    }
}

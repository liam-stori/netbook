using DotBook.Core.DTOs;
using MediatR;

namespace DotBook.Application.Queries.GetAllPublication
{
    public class GetAllPublicationByUserQuery : IRequest<IEnumerable<PublicationDTO>>
    {
        public GetAllPublicationByUserQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; private set; }
    }
}

using DotBook.Core.DTOs;
using MediatR;

namespace DotBook.Application.Queries.GetAllComment
{
    public class GetAllCommentQuery : IRequest<List<PublicationCommentDTO>>
    {
        public GetAllCommentQuery(int idPublication)
        {
            IdPublication = idPublication;
        }

        public int IdPublication { get; private set; }
    }
}

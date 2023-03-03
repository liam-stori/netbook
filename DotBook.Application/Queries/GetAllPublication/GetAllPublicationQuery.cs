using NetBook.Core.DTOs;
using MediatR;

namespace NetBook.Application.Queries.GetAllPublication
{
    public class GetAllPublicationQuery : IRequest<List<PublicationDTO>>
    {
    }
}

using DotBook.Core.DTOs;
using MediatR;

namespace DotBook.Application.Queries.GetAllPublication
{
    public class GetAllPublicationQuery : IRequest<List<PublicationDTO>>
    {
    }
}

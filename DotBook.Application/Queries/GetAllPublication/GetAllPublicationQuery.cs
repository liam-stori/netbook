using DotBook.Application.ViewModels;
using MediatR;

namespace DotBook.Application.Queries.GetAllPublication
{
    public class GetAllPublicationQuery : IRequest<List<PublicationViewModel>>
    {
    }
}

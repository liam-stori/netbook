using DotBook.Application.ViewModels;
using MediatR;

namespace DotBook.Application.Queries.GetPublicationById
{
    public class GetPublicationByIdQuery : IRequest<PublicationViewModel>
    {
        public GetPublicationByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}

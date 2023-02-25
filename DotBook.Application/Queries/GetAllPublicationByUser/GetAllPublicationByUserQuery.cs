using DotBook.Application.ViewModels;
using MediatR;

namespace DotBook.Application.Queries.GetAllPublication
{
    public class GetAllPublicationByUserQuery : IRequest<List<PublicationViewModel>>
    {
        public GetAllPublicationByUserQuery(int idUser)
        {
            IdUser = idUser;
        }

        public int IdUser { get; private set; }
    }
}

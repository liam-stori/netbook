using DotBook.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotBook.Application.Queries.GetAllComment
{
    public class GetAllCommentQuery : IRequest<List<CommentViewModel>>
    {
        public GetAllCommentQuery(int idPublication)
        {
            IdPublication = idPublication;
        }

        public int IdPublication { get; private set; }
    }
}

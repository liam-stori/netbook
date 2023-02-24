using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotBook.Application.Commands.DeletePublication
{
    public class DeletePublicationCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}

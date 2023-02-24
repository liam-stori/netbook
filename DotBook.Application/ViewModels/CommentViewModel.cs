using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotBook.Application.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; private set; }
        public int IdUser { get; private set; }
        public int IdPublication { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotBook.Core.DTOs
{
    public class PublicationCommentDTO
    {
        public PublicationCommentDTO() { }
        public PublicationCommentDTO(string username, string content)
        {
            Username = username;
            Content = content;
        }

        public string Username { get; private set; }
        public string Content { get; private set; }
    }
}

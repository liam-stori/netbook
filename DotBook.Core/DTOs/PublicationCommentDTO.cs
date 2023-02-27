using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotBook.Core.DTOs
{
    public class PublicationCommentDTO
    {
        public PublicationCommentDTO(int id, int idUser, string content, DateTime createdAt)
        {
            Id = id;
            IdUser = idUser;
            Content = content;
            CreatedAt = createdAt;
        }

        public int Id { get; private set; }
        public int IdUser { get; private set; }
        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}

using DotBook.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotBook.Core.Entities
{
    public class PublicationComment : BaseEntity
    {
        public PublicationComment(string content, DateTime createdAt, int idUser)
        {
            Content = content;
            IdUser = idUser;

            CreatedAt = DateTime.Now;
            Status = PublicationCommentStatusEnum.Enable;
        }

        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public PublicationCommentStatusEnum Status { get; private set; }
        public int IdUser { get; private set; }
        public User User { get; private set; }
    }
}

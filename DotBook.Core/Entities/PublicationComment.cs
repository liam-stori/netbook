using DotBook.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotBook.Core.Entities
{
    public class PublicationComment : BaseEntity
    {
        public PublicationComment(string content, int userId, int publicationId)
        {
            Content = content;
            UserId = userId;
            PublicationId = publicationId;

            CreatedAt = DateTime.Now;
            Status = PublicationCommentStatusEnum.Enable;
        }

        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public PublicationCommentStatusEnum Status { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; }
        public int PublicationId { get; private set; }
        public Publication Publication { get; private set; }
    }
}

using DotBook.Core.Enums;

namespace DotBook.Core.Entities
{
    public class PublicationComment : BaseEntity
    {
        public PublicationComment(string content, DateTime createdAt, int idUser, int idPublication)
        {
            Content = content;
            IdUser = idUser;
            IdPublication = idPublication;

            CreatedAt = DateTime.Now;
            Status = PublicationCommentStatusEnum.Enable;
        }

        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public PublicationCommentStatusEnum Status { get; private set; }
        public int IdUser { get; private set; }
        public User User { get; private set; }
        public int IdPublication { get; private set; }
        public Publication Publication { get; private set; }
    }
}

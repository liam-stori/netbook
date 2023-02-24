using DotBook.Core.Enums;

namespace DotBook.Core.Entities
{
    public class Publication : BaseEntity
    {
        public Publication(string content, DateTime createdAt, int idUser)
        {
            Content = content;
            IdUser = idUser;

            CreatedAt = DateTime.Now;
            Comments = new List<PublicationComment>();
            Status = PublicationStatusEnum.Enable;
        }

        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public PublicationStatusEnum Status { get; private set; }
        public int IdUser { get; private set; }
        public User User { get; private set; }
        public List<PublicationComment> Comments { get; private set; }

        public void Disabled()
        {
            Status = PublicationStatusEnum.Disable;
        }
    }
}

using DotBook.Core.Enums;

namespace DotBook.Core.Entities
{
    public class Publication : BaseEntity
    {
        public Publication(string content, int userId)
        {
            Content = content;
            UserId = userId;

            CreatedAt = DateTime.Now;
            Comments = new List<PublicationComment>();
            Status = PublicationStatusEnum.Enable;
        }

        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public PublicationStatusEnum Status { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; }
        public ICollection<PublicationComment> Comments { get; private set; }

        public void Disabled()
        {
            Status = PublicationStatusEnum.Disable;
        }
    }
}

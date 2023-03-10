using NetBook.Core.Enums;
using System.Collections.ObjectModel;

namespace NetBook.Core.Entities
{
    public class Publication : BaseEntity
    {
        public Publication() { }

        public Publication(string content, int userId)
        {
            Content = content;
            UserId = userId;

            CreatedAt = DateTime.Now;
            Comments = new Collection<Comment>();
            Status = PublicationStatusEnum.Enable;
        }

        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public PublicationStatusEnum Status { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; }
        public ICollection<Comment> Comments { get; private set; }

        public virtual void Disabled()
        {
            Status = PublicationStatusEnum.Disable;
        }

        public void Update(string content)
        {
            Content = content;
        }
    }
}

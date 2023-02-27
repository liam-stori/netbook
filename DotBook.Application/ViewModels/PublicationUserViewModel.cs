using DotBook.Core.Entities;

namespace DotBook.Application.ViewModels
{
    public class PublicationUserViewModel
    {
        public PublicationUserViewModel(string content, DateTime createdAt, string username, List<PublicationComment> comments)
        {
            Content = content;
            CreatedAt = createdAt;
            Username = username;
            Comments = comments;
        }

        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string Username { get; private set; }
        public List<PublicationComment> Comments { get; private set; }
    }
}

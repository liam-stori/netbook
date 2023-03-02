using System.Text.Json.Serialization;

namespace DotBook.Core.DTOs
{
    public class PublicationDTO
    {
        public PublicationDTO() { }

        public PublicationDTO(string content, string username)
        {
            Content = content;
            Username = username;
        }

        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public int Status { get; set; }
        [JsonIgnore]
        public ICollection<CommentDTO> Comments { get; set; }

        public ICollection<CommentDTO> FilteredComments
        {
            get { return Comments.Where(c => c.Status == 0).ToList(); }
        }
    }
}

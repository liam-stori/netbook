using System.Text.Json.Serialization;

namespace DotBook.Core.DTOs
{
    public class CommentDTO
    {
        public CommentDTO() { }

        public string Username { get; set; }
        public string Content { get; set; }
        [JsonIgnore]
        public int Status { get; set; }
    }
}

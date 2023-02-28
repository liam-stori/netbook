namespace DotBook.Core.DTOs
{
    public class PublicationDTO
    {
        public PublicationDTO() { }

        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Username { get; set; }
        public ICollection<PublicationCommentDTO> Comments { get; set; }
    }
}

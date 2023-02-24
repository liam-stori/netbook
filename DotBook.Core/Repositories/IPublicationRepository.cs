using DotBook.Core.Entities;

namespace DotBook.Core.Repositories
{
    public interface IPublicationRepository
    {
        Task<Publication> GetByIdAsync(int id);
        Task<List<Publication>> GetAllAsync();
        Task<List<PublicationComment>> GetAllCommentsAsync(Publication publication);
        Task AddAsync(Publication publication);
        Task AddCommentAsync(PublicationComment publicationComment);
        Task SaveChangesAsync();
    }
}

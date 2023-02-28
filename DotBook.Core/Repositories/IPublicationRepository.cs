using DotBook.Core.DTOs;
using DotBook.Core.Entities;

namespace DotBook.Core.Repositories
{
    public interface IPublicationRepository
    {
        Task<Publication> GetByIdAsync(int id);
        Task<List<PublicationDTO>> GetAllAsync();
        Task<List<PublicationDTO>> GetAllByUserIdAsync(int userId);
        Task<List<PublicationCommentDTO>> GetAllCommentsAsync(Publication publication);
        Task AddAsync(Publication publication);
        Task AddCommentAsync(PublicationComment publicationComment);
        Task SaveChangesAsync();
    }
}

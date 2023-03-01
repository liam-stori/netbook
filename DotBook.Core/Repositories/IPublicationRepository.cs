using DotBook.Core.DTOs;
using DotBook.Core.Entities;

namespace DotBook.Core.Repositories
{
    public interface IPublicationRepository
    {
        Task<Publication> GetByIdAsync(int id);
        Task<List<PublicationDTO>> GetAllAsync();
        Task<List<PublicationDTO>> GetAllByUserIdAsync(int userId);
        Task AddAsync(Publication publication);
        Task SaveChangesAsync();
    }
}

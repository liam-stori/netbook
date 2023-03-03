using NetBook.Core.DTOs;
using NetBook.Core.Entities;

namespace NetBook.Core.Repositories
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

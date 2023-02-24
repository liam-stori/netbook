using DotBook.Core.Entities;

namespace DotBook.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<User> GetByEmailAndPasswordAsync(string email, string password);
        Task AddAsync(User user);
        Task SaveChangesAsync();
    }
}

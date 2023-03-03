using NetBook.Core.Entities;
using NetBook.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace NetBook.Infrastructure.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NetBookDbContext _dbContext;
        public UserRepository(NetBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetByEmailAndPasswordAsync(string email, string password)
        {
            return await _dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Email == email 
                && u.Password == password);
        }

        public async Task AddAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

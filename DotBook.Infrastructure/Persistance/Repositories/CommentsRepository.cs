using NetBook.Core.Entities;
using NetBook.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace NetBook.Infrastructure.Persistance.Repositories
{
    public class CommentsRepository : ICommentRepository
    {
        private readonly NetBookDbContext _dbContext;
        public CommentsRepository(NetBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            return await _dbContext
                .Comments
                .FirstOrDefaultAsync(pc => pc.Id == id);
        }

        public async Task AddAsync(Comment comment)
        {
            await _dbContext.Comments.AddAsync(comment);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

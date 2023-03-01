using DotBook.Core.Entities;
using DotBook.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DotBook.Infrastructure.Persistance.Repositories
{
    public class CommentsRepository : ICommentRepository
    {
        private readonly DotBookDbContext _dbContext;
        public CommentsRepository(DotBookDbContext dbContext)
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

using DotBook.Core.Entities;

namespace DotBook.Core.Repositories
{
    public interface ICommentRepository
    {
        Task<Comment> GetByIdAsync(int id);
        Task AddAsync(Comment comment);
        Task SaveChangesAsync();
    }
}

using NetBook.Core.Entities;

namespace NetBook.Core.Repositories
{
    public interface ICommentRepository
    {
        Task<Comment> GetByIdAsync(int id);
        Task AddAsync(Comment comment);
        Task SaveChangesAsync();
    }
}

using DotBook.Core.DTOs;
using DotBook.Core.Entities;
using DotBook.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DotBook.Infrastructure.Persistance.Repositories
{
    public class PublicationRepository : IPublicationRepository
    {
        private readonly DotBookDbContext _dbContext;
        public PublicationRepository(DotBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Publication> GetByIdAsync(int id)
        {
            return await _dbContext
                .Publications
                .Include(p => p.Comments)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Publication>> GetAllAsync()
        {
            return await _dbContext.Publications.ToListAsync();
        }

        public async Task<List<Publication>> GetAllByUserIdAsync(int userId)
        {
            return await _dbContext
                .Publications
                .Include(p => p.User)
                .Include(p => p.Comments)
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }

        public async Task<List<PublicationCommentDTO>> GetAllCommentsAsync(Publication publication)
        {
            return await _dbContext
                .PublicationsComment
                .Where(p => p.Id == publication.Id)
                .Select(p => new PublicationCommentDTO(
                    p.Id, 
                    p.UserId, 
                    p.Content, 
                    p.CreatedAt))
                .ToListAsync();
        }

        public async Task AddAsync(Publication publication) 
        {
            await _dbContext.Publications.AddAsync(publication);
        }

        public async Task AddCommentAsync(PublicationComment publicationComment)
        {
            await _dbContext.PublicationsComment.AddAsync(publicationComment);
        }     

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }                
    }
}

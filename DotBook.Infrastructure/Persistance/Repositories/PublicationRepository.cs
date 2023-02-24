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
            return await _dbContext.Publications
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Publication>> GetAllAsync()
        {
            return await _dbContext.Publications.ToListAsync();
        }
        public async Task<List<PublicationComment>> GetAllCommentsAsync(Publication publication)
        {
            return await _dbContext.PublicationsComment
                .Where(p => p.IdPublication == publication.Id)
                .Select(p => p.Publication.Comments)
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

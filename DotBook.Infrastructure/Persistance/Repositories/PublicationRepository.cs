using AutoMapper;
using AutoMapper.QueryableExtensions;
using DotBook.Core.DTOs;
using DotBook.Core.Entities;
using DotBook.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DotBook.Infrastructure.Persistance.Repositories
{
    public class PublicationRepository : IPublicationRepository
    {
        private readonly DotBookDbContext _dbContext;
        private readonly IMapper _mapper;
        public PublicationRepository(DotBookDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Publication> GetByIdAsync(int id)
        {
            return await _dbContext
                .Publications
                .Include(p => p.Comments)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<PublicationDTO>> GetAllAsync()
        {
            return await _dbContext
                .Publications
                .Include(p => p.Comments)
                .ProjectTo<PublicationDTO>(_mapper.ConfigurationProvider)
                .Where(p => p.Status == 0)
                .ToListAsync();
        }

        public async Task<List<PublicationDTO>> GetAllByUserIdAsync(int userId)
        {
            return await _dbContext
                .Publications
                .Include(p => p.User)
                .Include(p => p.Comments)
                .Where(p => p.UserId == userId && p.Status == 0)
                .Select(p => new PublicationDTO
                {
                    Content = p.Content,
                    CreatedAt = p.CreatedAt,
                    Username = p.User.FirstName,
                    Comments = p.Comments
                        .Where(c => c.Status == 0)
                        .Select(c => new CommentDTO
                        {
                            Content = c.Content,
                            Username = c.User.FirstName
                        })
                        .ToList()
                })
                .ToListAsync();
        }

        public async Task AddAsync(Publication publication) 
        {
            await _dbContext.Publications.AddAsync(publication);
        }    

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }                
    }
}

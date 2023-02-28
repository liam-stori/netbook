using AutoMapper;
using AutoMapper.QueryableExtensions;
using DotBook.Core.DTOs;
using DotBook.Core.Entities;
using DotBook.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
                .ToListAsync();
        }

        public async Task<List<PublicationDTO>> GetAllByUserIdAsync(int userId)
        {
            return await _dbContext
                .Publications
                .Include(p => p.User)
                .Include(p => p.Comments)
                .Where(p => p.UserId == userId)
                .ProjectTo<PublicationDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<List<PublicationCommentDTO>> GetAllCommentsAsync(Publication publication)
        {
            return await _dbContext
                .PublicationsComment
                .Include(u => u.User)
                .Where(p => p.Id == publication.Id)
                .ProjectTo<PublicationCommentDTO>(_mapper.ConfigurationProvider)
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

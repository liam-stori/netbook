using DotBook.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DotBook.Infrastructure.Persistance
{
    public class DotBookDbContext : DbContext
    {
        public DotBookDbContext(DbContextOptions<DotBookDbContext> options) : base(options) { }

        public DbSet<Publication> Publications { get; set; }
        public DbSet<PublicationComment> PublicationsComment { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

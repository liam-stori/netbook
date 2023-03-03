using NetBook.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace NetBook.Infrastructure.Persistance
{
    public class NetBookDbContext : DbContext
    {
        public NetBookDbContext(DbContextOptions<NetBookDbContext> options) : base(options) { }

        public DbSet<Publication> Publications { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

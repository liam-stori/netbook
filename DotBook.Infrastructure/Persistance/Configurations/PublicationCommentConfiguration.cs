using DotBook.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotBook.Infrastructure.Persistance.Configurations
{
    public class PublicationCommentConfiguration : IEntityTypeConfiguration<PublicationComment>
    {
        public void Configure(EntityTypeBuilder<PublicationComment> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}

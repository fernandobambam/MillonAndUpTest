using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable("Property");

            builder.HasKey(x => x.IdProperty);

            builder.HasMany(x => x.Images)
                   .WithOne(x => x.Property)
                   .HasForeignKey(x => x.IdPropertyImage);

            builder.Ignore(x => x.Owner);
            builder.Ignore(x => x.PropertyTrace);
            builder.Ignore(x => x.Images);
        }
    }
}

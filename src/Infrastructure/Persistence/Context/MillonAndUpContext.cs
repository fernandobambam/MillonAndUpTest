using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context
{
    public class MillonAndUpContext : DbContext, IMillonAndUpContext
    {
        public MillonAndUpContext()
        {
        }

        public MillonAndUpContext(DbContextOptions<MillonAndUpContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<PropertyImage> PropertiesImages { get; set; }
        public virtual DbSet<PropertyTrace> PropertiesTraces { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OwnerConfiguration());
            modelBuilder.ApplyConfiguration(new PropertyConfiguration());
            modelBuilder.ApplyConfiguration(new PropertyImageConfiguration());
            modelBuilder.ApplyConfiguration(new PropertyTraceConfiguration());
        }

        async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}

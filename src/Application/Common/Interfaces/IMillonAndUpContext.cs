using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IMillonAndUpContext
    {
        DbSet<Owner> Owners { get; set; }
        DbSet<Property> Properties { get; set; }
        DbSet<PropertyImage> PropertiesImages { get; set; }
        DbSet<PropertyTrace> PropertiesTraces { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

using Domain.Entities;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Application.UnitTest.Common
{
    public class MillonAndUpContextFactory
    {
        public static MillonAndUpContext Create()
        {
            var options = new DbContextOptionsBuilder<MillonAndUpContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new MillonAndUpContext(options);

            context.Database.EnsureCreated();

            context.Owners.AddRange(new[]
            {
                new Domain.Entities.Owner { IdOwner = 1, Name = "OwnerTest", Birthday = DateTime.Now, Address = "AddressTest", Photo = "test.jpg"}
            });

            context.Properties.AddRange(new[]
            {
                new Property {IdProperty = 1, Name = "Property Test", Address = "Address Test", Price = 100, CodeInternal = "1234", Year = 2023, IdOwner = 1 },
                new Property {IdProperty = 2, Name = "Property Test 2", Address = "Address Test 2", Price = 100, CodeInternal = "1234", Year = 2023, IdOwner = 1 },
                new Property {IdProperty = 3, Name = "Property Test 3", Address = "Address Test 3", Price = 200, CodeInternal = "1234", Year = 2015, IdOwner = 1 }
            });

            context.SaveChanges();

            return context;
        }

        public static void Destroy(MillonAndUpContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}

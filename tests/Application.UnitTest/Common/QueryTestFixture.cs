using Application.Common.Mappings;
using AutoMapper;
using Infrastructure.Persistence.Context;

namespace Application.UnitTest.Common
{
    public class QueryTestFixture : IDisposable
    {
        public MillonAndUpContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public QueryTestFixture()
        {
            Context = MillonAndUpContextFactory.Create();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutomapperProfile>();
            });

            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            MillonAndUpContextFactory.Destroy(Context);
        }
    }
}

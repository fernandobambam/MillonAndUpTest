using Infrastructure.Persistence.Context;

namespace Application.UnitTest.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly MillonAndUpContext _context;

        public CommandTestBase()
        {
            _context = MillonAndUpContextFactory.Create();
        }

        public void Dispose()
        {
            MillonAndUpContextFactory.Destroy(_context);
        }
    }
}

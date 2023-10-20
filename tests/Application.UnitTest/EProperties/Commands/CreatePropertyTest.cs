using Application.EProperties.Commands.CreateProperty;
using Application.UnitTest.Common;
using Domain.Exceptions;

namespace Application.UnitTest.EProperties.Commands
{
    [TestFixture]
    public class CreatePropertyTest : CommandTestBase
    {
        private readonly CreatePropertyCommand _sut;

        public CreatePropertyTest()
            :base()
        {
            _sut = new CreatePropertyCommand(_context);
        }

        [Test]
        public void CreatePropertyCommandThrowNotFoundException()
        {
            CreatePropertyRequest request = new CreatePropertyRequest()
            {
                Name = "Property test",
                Address = "Address Test",
                IdOwner = 10000
            };

            async Task Act() => await _sut.Handle(request, CancellationToken.None);

            Assert.That(Act, Throws.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task CreatePropertyCommandSuccessful()
        {
            CreatePropertyRequest request = new CreatePropertyRequest()
            {
                Name = "Property test",
                Address = "Address Test",
                Price = 100000,
                Year = 2023,
                IdOwner = 1
            };

            await _sut.Handle(request, CancellationToken.None);

            var result = _context.Properties.Where(x => x.Name == request.Name).FirstOrDefault();
            Assert.IsNotNull(result);
        }
    }
}

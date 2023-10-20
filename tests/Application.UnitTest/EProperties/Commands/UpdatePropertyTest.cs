using Application.EProperties.Commands.ChangePrice;
using Application.EProperties.Commands.UpdateProperty;
using Application.UnitTest.Common;
using Domain.Entities;
using Domain.Exceptions;

namespace Application.UnitTest.EProperties.Commands
{
    [TestFixture]
    public class UpdatePropertyTest : CommandTestBase
    {
        private readonly UpdatePropertyCommand _sut;

        public UpdatePropertyTest()
            :base()
        {
            _sut = new UpdatePropertyCommand(_context);    
        }

        [Test]
        public void UpdatePropertyCommandThrowNotFoundException()
        {
            UpdatePropertyRequest request = new UpdatePropertyRequest()
            {
                IdProperty = 1000,
                Name = "New Name"
            };

            async Task Act() => await _sut.Handle(request, CancellationToken.None);

            Assert.That(Act, Throws.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task UpdatePropertyCommandSuccessful()
        {
            UpdatePropertyRequest request = new UpdatePropertyRequest()
            {
                IdProperty = 1,
                Name = "New Name"
            };

            await _sut.Handle(request, CancellationToken.None);

            Property? result = await _context.Properties.FindAsync(request.IdProperty);
            Assert.AreEqual(request.Name, result.Name);
        }
    }
}

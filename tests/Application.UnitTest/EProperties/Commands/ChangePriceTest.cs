using Application.EProperties.Commands.ChangePrice;
using Application.UnitTest.Common;
using Domain.Exceptions;

namespace Application.UnitTest.EProperties.Commands
{
    [TestFixture]
    public class ChangePriceTest : CommandTestBase
    {
        private readonly ChangePriceCommand _sut;

        public ChangePriceTest()
            : base()
        {
            _sut = new ChangePriceCommand(_context);
        }

        [Test]
        public void ChangePriceCommandThrowNotFoundException()
        {
            ChangePriceRequest request = new ChangePriceRequest()
            {
                IdProperty = 1000,
                Price = 5000
            };

            async Task Act() => await _sut.Handle(request, CancellationToken.None);

            Assert.That(Act, Throws.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task ChangePriceCommandSuccessful()
        {
            ChangePriceRequest request = new ChangePriceRequest()
            {
                IdProperty = 1,
                Price = 50000
            };

            await _sut.Handle(request, CancellationToken.None);

            var result = _context.Properties.Where(x => x.Price == request.Price).FirstOrDefault(); 
            Assert.IsNotNull(result);
        }

    }
}

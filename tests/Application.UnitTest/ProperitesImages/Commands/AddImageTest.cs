using Application.ProperitesImages.Commands.AddImage;
using Application.UnitTest.Common;
using Domain.Exceptions;

namespace Application.UnitTest.ProperitesImages.Commands
{
    [TestFixture]
    public class AddImageTest : CommandTestBase
    {
        private readonly AddImageCommand _sut;

        public AddImageTest()
            : base()
        {
            _sut = new AddImageCommand(_context);
        }

        [Test]
        public void AddImageCommandThrowNotFoundException()
        {
            AddImageRequest request = new AddImageRequest()
            {
                IdProperty = 1000
            };

            async Task Act() => await _sut.Handle(request, CancellationToken.None);

            Assert.That(Act, Throws.TypeOf<NotFoundException>());
        }
    }
}

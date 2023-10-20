using Application.Owners.Commands.DeleteOwner;
using Application.UnitTest.Common;
using Domain.Exceptions;

namespace Application.UnitTest.Owner.Commands
{
    public class DeleteOwnerTest : CommandTestBase
    {
        private readonly DeleteOwnerCommand _sut;

        public DeleteOwnerTest()
            :base()
        {
            _sut = new DeleteOwnerCommand(_context);
        }

        [Test]
        public void DeleteOwnerCommandThrowNotFoundException()
        {
            DeleteOwnerRequest request = new DeleteOwnerRequest()
            {
                IdOwner = 1000
            };

            async Task Act() => await _sut.Handle(request, CancellationToken.None);

            Assert.That(Act, Throws.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task DeleteOwnerCommandSuccessful()
        {
            DeleteOwnerRequest request = new DeleteOwnerRequest()
            {
                IdOwner = 1
            };

            await _sut.Handle(request, CancellationToken.None);

            var result = _context.Owners.Where(x => x.IdOwner == request.IdOwner).FirstOrDefault();
            Assert.IsNull(result);
        }

    }
}

using Application.Owners.Commands.CreateOwner;
using Application.UnitTest.Common;

namespace Application.UnitTest.Owner.Commands
{
    public class CreateOwnerTest : CommandTestBase
    {
        private readonly CreateOwnerCommand _sut;

        public CreateOwnerTest()
            :base()
        {
            _sut = new CreateOwnerCommand(_context);
        }

        [Test]
        public async Task CreateOwnerCommandSuccessful()
        {
            CreateOwnerRequest request = new CreateOwnerRequest()
            {
                Name = "owner test 2",
                Address = "Owner Test2",
                Photo = "Owner.jpg",
                Birthday = "20/10/203"
            };

            await _sut.Handle(request, CancellationToken.None);

            var result = _context.Owners.Where(x => x.Name == request.Name).FirstOrDefault();
            Assert.IsNotNull(result);
        }
    }
}

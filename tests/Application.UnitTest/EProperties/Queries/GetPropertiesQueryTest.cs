using Application.Common.Interfaces;
using Application.EProperties.Queries.GetProperties;
using Application.UnitTest.Common;
using AutoMapper;
using Domain.Common;
using Microsoft.Extensions.Options;
using Moq;

namespace Application.UnitTest.EProperties.Queries
{
    public class GetPropertiesQueryTest : QueryTestFixture
    {
        private readonly GetPropertiesQuery _sut;
        private readonly IMillonAndUpContext _millonAndUpContext;
        private readonly IMapper _mapper;
        private readonly Mock<IOptions<FiltersOptions>> _options;

        private readonly FiltersOptions _paginationOptions;

        public GetPropertiesQueryTest()
            : base()
        {
            _millonAndUpContext = Context;
            _mapper = Mapper;
            _options = new Mock<IOptions<FiltersOptions>>();

            FiltersOptions paginationOptions = new()
            {
                DefaultPageNumber = 1,
                DefaultPageSize = 10
            };
            _options.Setup(opt => opt.Value).Returns(paginationOptions);

            _sut = new GetPropertiesQuery(_millonAndUpContext, _mapper, _options.Object);
        }


        [Test]
        public async Task GetPropertiesQueryByPrice()
        {
            GetPropertiesRequest request = new GetPropertiesRequest()
            {
                Price = 100
            };

            var result = await _sut.Handle(request, CancellationToken.None);

            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public async Task GetPropertiesQueryByOwner()
        {
            GetPropertiesRequest request = new GetPropertiesRequest()
            {
                IdOwner = 1
            };

            var result = await _sut.Handle(request, CancellationToken.None);

            Assert.AreEqual(3, result.Count);
        }

        [Test]
        public async Task GetPropertiesQueryByName()
        {
            GetPropertiesRequest request = new GetPropertiesRequest()
            {
                Name = "Property Test"
            };

            var result = await _sut.Handle(request, CancellationToken.None);

            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public async Task GetPropertiesQueryByAddress()
        {
            GetPropertiesRequest request = new GetPropertiesRequest()
            {
                Address = "Address Test"
            };

            var result = await _sut.Handle(request, CancellationToken.None);

            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public async Task GetPropertiesQueryByYear()
        {
            GetPropertiesRequest request = new GetPropertiesRequest()
            {
                Year = 2023
            };

            var result = await _sut.Handle(request, CancellationToken.None);

            Assert.AreEqual(2, result.Count);
        }
    }
}

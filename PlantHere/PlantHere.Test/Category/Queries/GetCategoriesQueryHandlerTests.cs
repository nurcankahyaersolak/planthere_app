using AutoMapper;
using Moq;
using PlantHere.Application.CQRS.Category.Queries.GetCategories;
using PlantHere.Application.Interfaces;
using PlantHere.Application.Mapping;
using PlantHere.Test.Mocks;
using Xunit;

namespace PlantHere.Test.Category.Queries
{
    public class GetCategoriesQueryHandlerTests
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly GetCategoriesQueryHandler _handler;

        public GetCategoriesQueryHandlerTests()
        {
            //Arrange
            _mockUow = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<CategoryProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _handler = new GetCategoriesQueryHandler(_mockUow.Object, _mapper);
        }

        [Fact]
        public async Task GetCategoriesQueryHandler_HandlerExecutes_ResultCount3()
        {
            //Act

            var result = await _handler.Handle(new GetCategoriesQuery(), CancellationToken.None);

            //Assert

            Assert.Equal(3, result.Count());
        }

    }
}

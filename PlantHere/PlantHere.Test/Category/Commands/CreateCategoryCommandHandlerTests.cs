using AutoMapper;
using Moq;
using PlantHere.Application.CQRS.Category.Cammands.CreateCategory;
using PlantHere.Application.Interfaces;
using PlantHere.Application.Mapping;
using PlantHere.Test.Mocks;
using Xunit;

namespace PlantHere.Test.Category.Commands
{
    public class CreateCategoryCommandHandlerTests
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly CreateCategoryCommandHandler _handler;
        private CreateCategoryCommand _request;

        public CreateCategoryCommandHandlerTests()
        {
            //Arrange
            _mockUow = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<CategoryProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _handler = new CreateCategoryCommandHandler(_mapper, _mockUow.Object);

            _request = new CreateCategoryCommand("Salon Bitkisi", "Hall Plant");

        }


        [Fact]
        public async Task CreateCategoryHandleTest_HandlerExecutes_ResultTypeCreateCatoryCommandResult()
        {

            var result = await _handler.Handle(_request, CancellationToken.None);

            Assert.IsType<CreateCategoryCommandResult>(result);
        }
    }
}

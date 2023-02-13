using AutoMapper;
using Moq;
using PlantHere.Application.CQRS.Product.Queries.GetProductByUniqueId;
using PlantHere.Application.Interfaces;
using PlantHere.Application.Mapping;
using PlantHere.Test.Mocks;

namespace PlantHere.Test.Products.Queries
{
    public class GetProductByUniqueIdQueryHandlerTests
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly GetProductByUniqueIdQueryHandler _handler;

        public GetProductByUniqueIdQueryHandlerTests()
        {
            //Arrange
            _mockUow = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ProductProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _handler = new GetProductByUniqueIdQueryHandler(_mockUow.Object, _mapper);
        }

    }
}

using AutoMapper;
using FluentValidation;
using Moq;
using PlantHere.Application.CQRS.Product.Commands.CreateProduct;
using PlantHere.Application.Interfaces;
using PlantHere.Application.Mapping;
using PlantHere.Test.Mocks;

namespace PlantHere.Test.Products.Commands
{
    public class CreateProductCommandHandlerTests
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly CreateProductCommandHandler _handler;
        private readonly Mock<IEnumerable<IValidator<CreateProductCommand>>> _validators;
        private CreateProductCommand _request;

        public CreateProductCommandHandlerTests()
        {
            //Arrange
            _mockUow = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ProductProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _handler = new CreateProductCommandHandler(_mapper, _mockUow.Object);

            _request = new CreateProductCommand
            {
                Name = "Variegated",
                Description = "Kırmızı",
                Price = 250,
                SellerId = "d8a07002-0c3a-4add-874b-dd2b1e33aaae",
                CategoryId = 2,
                Stock = 2,
                Discount = 10
            };

        }

    }
}

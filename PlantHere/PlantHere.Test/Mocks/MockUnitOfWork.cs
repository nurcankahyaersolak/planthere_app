using Moq;
using PlantHere.Application.Interfaces;
using PlantHere.Domain.Aggregate.CategoryAggregate;

namespace PlantHere.Test.Mocks
{
    public static class MockUnitOfWork
    {

        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            //Arrange
            var mockUow = new Mock<IUnitOfWork>();
            var mockProductRepo = MockProductRepository.GetProductRepository();
            mockUow.Setup(r => r.GetGenericRepository<Product>()).Returns(mockProductRepo.Object);
            return mockUow;

        }
    }
}

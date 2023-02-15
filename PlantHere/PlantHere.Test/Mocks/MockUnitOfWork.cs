using Moq;
using PlantHere.Application.Interfaces;
using ModelCategory = PlantHere.Domain.Aggregate.CategoryAggregate.Category;

namespace PlantHere.Test.Mocks
{
    public static class MockUnitOfWork
    {

        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            //Arrange
            var mockUow = new Mock<IUnitOfWork>();
            var mockProductRepo = MockCategoryRepository.GetCategoryRepository();
            mockUow.Setup(r => r.GetGenericRepository<ModelCategory>()).Returns(mockProductRepo.Object);

            return mockUow;

        }
    }
}

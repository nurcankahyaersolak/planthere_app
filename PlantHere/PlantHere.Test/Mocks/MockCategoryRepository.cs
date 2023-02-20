using Moq;
using PlantHere.Application.Interfaces.Repositories;
using System.Linq.Expressions;
using ModelCategory = PlantHere.Domain.Aggregate.CategoryAggregate.Category;

namespace PlantHere.Test.Mocks
{
    public static class MockCategoryRepository
    {

        public static Mock<IRepository<ModelCategory>> GetCategoryRepository()
        {
            {
                //Arrange
                var _products = new List<ModelCategory>()
                {
                    new ModelCategory { Id = 1, UniqueId = "d8a07002-0c3a-4add-874b-dd2b1e33aaae", NameTr = "Kaktus", NameEn = "Cactus", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
                    new ModelCategory { Id = 2, UniqueId = "d8a07002-0c3a-4add-874b-dd2b1e33aaa2", NameTr = "Sukulent", NameEn = "Succulent", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
                    new ModelCategory { Id = 3, UniqueId = "d8a07002-0c3a-4add-874b-dd2b1e33aaa3", NameTr = "Orkide", NameEn = "Orchid", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now }
                };

                var mockRepo = new Mock<IRepository<ModelCategory>>();
                mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(_products);
                mockRepo.Setup(r => r.AddAsync((It.IsAny<ModelCategory>()))).Returns((Task.CompletedTask));
                mockRepo.Setup(r => r.GetQueryableAsNoTracking()).Returns(_products.AsQueryable());
                mockRepo.Setup(r => r.Where(It.IsAny<Expression<Func<ModelCategory, bool>>>())).Returns(_products.AsQueryable());
                return mockRepo;
            }
        }
    }
}
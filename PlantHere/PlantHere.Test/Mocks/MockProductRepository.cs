using Moq;
using PlantHere.Application.Interfaces.Repositories;
using PlantHere.Domain.Aggregate.CategoryAggregate;
using System.Linq.Expressions;

namespace PlantHere.Test.Mocks
{
    public static class MockProductRepository
    {
        public static void Include(this IQueryable<Product> products, Expression<Func<Product, object>> includeProperty)
        {

        }

        public static Mock<IRepository<Product>> GetProductRepository()
        {
            //Arrange
            var _products = new List<Product>() { new Product { Id = 1,UniqueId = "d8a07002-0c3a-4add-874b-dd2b1e33aaae", Name = "Pachyphytum Oviferum", Description = "Baden Şekeri", Stock = 5, Price = 50, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, CategoryId = 2, SellerId = "d8a07002-0c3a-4add-874b-dd2b1e33aaae", Discount = 0 },
                            new Product { Id = 2,UniqueId = "d8a07002-0c3a-4add-874b-dd2b1e33aaa2", Name = "Echeveria Lola", Description = "Beyaz Renk Muhteşem Form", Stock = 2, Price = 75, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, CategoryId = 2, SellerId = "d8a07002-0c3a-4add-874b-dd2b1e33aaae", Discount = 15 },
                            new Product { Id = 3,UniqueId = "d8a07002-0c3a-4add-874b-dd2b1e33aaa3", Name = "Cremnosedum Little Gem", Description = "Güneşte Rengi Koyulaşır", Stock = 2, Price = 150, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, CategoryId = 2, SellerId = "d8a07002-0c3a-4add-874b-dd2b1e33aaae", Discount = 0 },
                            new Product { Id = 4,UniqueId = "d8a07002-0c3a-4add-874b-dd2b1e33aaa4",Name = "Callisia Repens (Pink Lady)", Description = "Pembe Yapraklı Telgraf Çiçeği", Stock = 3, Price = 100, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, CategoryId = 2, SellerId = "d8a07002-0c3a-4add-874b-dd2b1e33aaae", Discount = 25 },
                            new Product { Id = 5,UniqueId = "d8a07002-0c3a-4add-874b-dd2b1e33aaa5", Name = "Haworthia Fasciata Hibrid", Description = "Zebra Bitkisi", Stock = 2, Price = 45, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, CategoryId = 2, SellerId = "d8a07002-0c3a-4add-874b-dd2b1e33aaae", Discount = 20 } };

            var mockRepo = new Mock<IRepository<Product>>();
            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(_products);
            mockRepo.Setup(r => r.AddAsync((It.IsAny<Product>()))).Returns((Task.CompletedTask));
            mockRepo.Setup(r => r.GetQueryable()).Returns(_products.AsQueryable());
            mockRepo.Setup(r => r.Where(It.IsAny<Expression<Func<Product, bool>>>())).Returns(_products.AsQueryable());


            return mockRepo;
        }
    }
}

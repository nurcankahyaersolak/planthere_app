using PlantHere.Domain.Common.Class;

namespace PlantHere.Domain.Aggregate.CategoryAggregate
{
    public class Product : BaseEntity
    {
        public Product(string? name, string? description, int stock, int price, int categoryId)
        {
            Name = name;
            Description = description;
            Stock = stock;
            Price = price;
            CategoryId = categoryId;
        }

        public Product()
        {

        }

        public ICollection<Image>? Images { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public string SellerId { get; set; }

        public int CategoryId { get; set; }

        public int Discount { get; set; }

        public string? Care { get; set; }

        public Category? Category { get; set; }

        public decimal GetDiscountedPrice()
        {
            return Price - (Price * Discount) / 100;
        }
    }
}

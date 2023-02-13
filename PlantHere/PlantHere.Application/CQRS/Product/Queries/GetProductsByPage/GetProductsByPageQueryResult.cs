using PlantHere.Domain.Aggregate.CategoryAggregate;

namespace PlantHere.Application.CQRS.Product.Queries.GetProductsByPage
{
    public class GetProductsByPageQueryResult
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public int Discount { get; set; }

        public decimal Price { get; set; }

        public decimal DiscountedPrice { get; set; }

        public string UniqueId { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}

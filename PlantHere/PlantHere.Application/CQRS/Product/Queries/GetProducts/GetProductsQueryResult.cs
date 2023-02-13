namespace PlantHere.Application.CQRS.Product.Queries.GetAllProducts
{
    public class GetProductsQueryResult
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string UniqueId { get; set; }

    }
}

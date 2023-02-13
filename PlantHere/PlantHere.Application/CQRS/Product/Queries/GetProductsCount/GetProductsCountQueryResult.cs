namespace PlantHere.Application.CQRS.Product.Queries.GetProductsCount
{
    public class GetProductsCountQueryResult
    {
        public int Count { get; set; }

        public GetProductsCountQueryResult(int count)
        {
            Count = count;
        }
    }
}

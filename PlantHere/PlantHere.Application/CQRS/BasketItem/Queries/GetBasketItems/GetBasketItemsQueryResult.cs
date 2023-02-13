namespace PlantHere.Application.CQRS.BasketItem.Queries.GetBasketItems
{
    public class GetBasketItemsQueryResult
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountedPrice { get; set; }
        public int Count { get; set; }

    }
}

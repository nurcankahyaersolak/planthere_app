namespace PlantHere.Application.Requests.BasketItems
{
    public class CreateBasketItemRequest
    {
        public string ProductId { get; set; }

        public string? UserId { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public decimal DiscountedPrice { get; set; }
    }
}

namespace PlantHere.Application.Requests.BasketItems
{
    public class UpdateBasketItemRequest
    {
        public string ProductId { get; set; }

        public string? UserId { get; set; }

        public int Count { get; set; }
    }
}

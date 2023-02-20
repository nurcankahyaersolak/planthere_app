namespace PlantHere.Application.Requests.BasketItems
{
    public class DeleteBasketItemRequest
    {
        public string? UserId { get; set; }

        public string ProductId { get; set; }
    }
}

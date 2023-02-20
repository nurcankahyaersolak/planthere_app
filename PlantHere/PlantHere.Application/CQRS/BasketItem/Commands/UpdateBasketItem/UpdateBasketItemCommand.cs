using PlantHere.Application.CQRS.Base;

namespace PlantHere.Application.CQRS.BasketItem.Commands.UpdateBasketItem
{
    public class UpdateBasketItemCommand : CommandBase<UpdateBasketItemCommandResult>
    {
        public string ProductId { get; set; }

        public string? UserId { get; set; }

        public int Count { get; set; }

        public UpdateBasketItemCommand(string productId, string? userId, int count)
        {
            ProductId = productId;
            UserId = userId;
            Count = count;
        }
    }
}

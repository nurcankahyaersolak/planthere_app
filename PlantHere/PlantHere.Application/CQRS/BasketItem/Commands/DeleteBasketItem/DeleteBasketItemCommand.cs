using PlantHere.Application.CQRS.Base;

namespace PlantHere.Application.CQRS.BasketItem.Commands.DeleteBasketItem
{
    public class DeleteBasketItemCommand : CommandBase<DeleteBasketItemCommandResult>
    {
        public string? UserId { get; set; }

        public string ProductId { get; set; }
    }
}

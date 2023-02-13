using PlantHere.Application.CQRS.Base;

namespace PlantHere.Application.CQRS.Basket.Commands.CreateBasket
{
    public class CreateBasketCommand : CommandBase<CreateBasketCommandResult>
    {
        public string UserId { get; set; }

        public CreateBasketCommand(string userId)
        {
            UserId = userId;
        }
    }
}

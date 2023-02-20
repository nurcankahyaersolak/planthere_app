using PlantHere.Application.CQRS.Base;

namespace PlantHere.Application.CQRS.BasketItem.Commands.CreateBasketItem
{
    public class CreateBasketItemCommand : CommandBase<CreateBasketItemCommandResult>
    {
        public string ProductId { get; set; }

        public string UserId { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public decimal DiscountedPrice { get; set; }

        public CreateBasketItemCommand(string productId, string userId, string productName, decimal price, decimal discountedPrice)
        {
            ProductId = productId;
            UserId = userId;
            ProductName = productName;
            Price = price;
            DiscountedPrice = discountedPrice;
        }
    }
}

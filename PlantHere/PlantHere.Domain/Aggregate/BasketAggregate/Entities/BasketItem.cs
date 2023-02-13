using PlantHere.Domain.Common.Class;

namespace PlantHere.Domain.Aggregate.BasketAggregate.Entities
{
    public class BasketItem : Entity
    {
        public string ProductId { get; private set; }

        public string ProductName { get; private set; }

        public decimal Price { get; private set; }

        public decimal DiscountedPrice { get; private set; }

        public int Count { get; private set; }

        public BasketItem()
        {
        }

        public BasketItem(string productId, string productName, decimal price, decimal discountedPrice)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
            Count = 1;
            DiscountedPrice = discountedPrice;
        }

        public void UpdateBasketItem(string productName, int count)
        {
            ProductName = productName;
            Count = count;
        }

        public void UpdateBasketItem(decimal price, int count)
        {
            Price = price;
            Count = count;
        }

        public void UpdateBasketItem(int count)
        {
            Count = count;
        }

    }
}

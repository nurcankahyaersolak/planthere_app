using PlantHere.Domain.Common.Class;

namespace PlantHere.Domain.Aggregate.OrderAggregate.Entities
{
    public class OrderItem : Entity
    {
        public string ProductId { get; private set; }
        public string ProductName { get; private set; }
        public decimal Price { get; private set; }
        public decimal DiscountedPrice { get; private set; }
        public int Count { get; private set; }

        public OrderItem()
        {
        }

        public OrderItem(string productId, string productName, decimal price, decimal discountedPrice, int count)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
            Count = count;
            DiscountedPrice = discountedPrice;
        }

        public void UpdateOrderItem(string productName, decimal price, int count)
        {
            ProductName = productName;
            Price = price;
            Count = count;
        }

    }
}

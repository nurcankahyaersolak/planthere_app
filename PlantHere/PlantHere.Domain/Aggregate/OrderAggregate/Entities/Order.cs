using PlantHere.Domain.Aggregate.OrderAggregate.DomainEvents;
using PlantHere.Domain.Aggregate.OrderAggregate.ValueObjects;
using PlantHere.Domain.Common.Class;
using PlantHere.Domain.Common.Interfaces;

namespace PlantHere.Domain.Aggregate.OrderAggregate.Entities
{
    public class Order : Entity, IAggregateRoot
    {
        public DateTime CreatedDate { get; private set; }

        public Address Address { get; private set; }

        public string BuyerId { get; private set; }

        public ICollection<OrderItem> OrderItems { get; private set; }

        public Order()
        {
        }

        public Order(string buyerId, Address address)
        {
            OrderItems = new List<OrderItem>();
            CreatedDate = DateTime.Now;
            BuyerId = buyerId;
            Address = address;
        }
        public Order(string buyerId, Address address, List<OrderItem> orderItems)
        {
            OrderItems = new List<OrderItem>();
            CreatedDate = DateTime.Now;
            BuyerId = buyerId;
            Address = address;
            AddOrderItems(orderItems);
        }

        public Order(int id, string buyerId, Address address)
        {
            Id = id;
            OrderItems = new List<OrderItem>();
            CreatedDate = DateTime.Now;
            BuyerId = buyerId;
            Address = address;
        }

        public void AddOrderItem(string productId, string productName, decimal price, decimal discountedPrice, int count)
        {
            var existProduct = OrderItems.Any(x => x.ProductId == productId);

            if (!existProduct)
            {
                var newOrderItem = new OrderItem(productId, productName, price, discountedPrice, count);

                OrderItems.Add(newOrderItem);
            }
        }

        public Order AddOrder(List<OrderItem> orderItems)
        {
            var order = new Order(BuyerId, Address);

            order.AddOrderItems(orderItems);

            return order;
        }

        public void AddOrderItems(List<OrderItem> orderItems)
        {
            foreach (var orderItem in orderItems)
            {
                OrderItems.Add(orderItem);
            }
        }

        public void UpdateOrder(string buyerId, Address address, List<OrderItem> orderItems)
        {
            BuyerId = buyerId;
            Address = address;

            foreach (var orderItem in orderItems)
            {
                orderItem.UpdateOrderItem(orderItem.ProductName, orderItem.Price, orderItem.Count);
            }
        }

        public decimal GetTotalPrice()
        {
            return OrderItems.Sum(x => x.Price * x.Count);
        }

        public decimal GetDiscountedTotalPrice()
        {
            return OrderItems.Sum(x => x.DiscountedPrice * x.Count);
        }

        private void AddOrderStartedDomainEvent(string buyerId)
        {
            var orderStartedDomainEvent = new OrderStartedDomainEvent(this, buyerId);

            this.AddDomainEvent(orderStartedDomainEvent);
        }

    }

}
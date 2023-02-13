using PlantHere.Domain.Common.Interfaces;
using ModelOder = PlantHere.Domain.Aggregate.OrderAggregate.Entities.Order;

namespace PlantHere.Domain.Aggregate.OrderAggregate.DomainEvents
{
    public class OrderStartedDomainEvent : IDomainEvent
    {
        public ModelOder Order { get; private set; }

        public string UserId { get; private set; }

        public OrderStartedDomainEvent(ModelOder order, string userId)
        {
            Order = order;
            UserId = userId;
        }
    }

}
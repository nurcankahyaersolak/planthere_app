using PlantHere.Domain.Aggregate.OrderAggregate.ValueObjects;
using PlantHere.Domain.Common.Interfaces;
using ModelBasket = PlantHere.Domain.Aggregate.BasketAggregate.Entities.Basket;

namespace PlantHere.Domain.Aggregate.BasketAggregate.DomainEvents
{
    public class BaketBuyStartedDomainEvent : IDomainEvent
    {
        public ModelBasket Basket { get; private set; }

        public Address Address { get; private set; }
        public int CardTypeId { get; }
        public string CardNumber { get; }
        public string CardSecurityNumber { get; }
        public string CardHolderName { get; }

        public BaketBuyStartedDomainEvent(ModelBasket basket, Address address, int cardTypeId, string cardNumber, string cardSecurityNumber, string cardHolderName)
        {
            Basket = basket;
            Address = address;
            CardTypeId = cardTypeId;
            CardNumber = cardNumber;
            CardSecurityNumber = cardSecurityNumber;
            CardHolderName = cardHolderName;
        }
    }

}
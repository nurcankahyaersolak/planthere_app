using PlantHere.Application.CQRS.Payment.Quries;
using ModelAddress = PlantHere.Domain.Aggregate.OrderAggregate.ValueObjects.Address;

namespace PlantHere.Application.Requests.Basket
{
    public class BuyBasketRequest
    {
        public string? UserId { get; set; }

        public ModelAddress Address { get; set; }

        public PaymentQueryResult Payment { get; set; }
    }
}

using PlantHere.Application.CQRS.Address.Queries;
using PlantHere.Application.CQRS.Base;
using PlantHere.Application.CQRS.OrderItem.Queries.GetOrderItems;

namespace PlantHere.Application.CQRS.Order.Commands.UpdateOrder
{
    public class UpdateOrderCommand : CommandBase<UpdateOrderCommandResult>
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public AddressQueryResult? Address { get; set; }

        public string BuyerId { get; set; }

        public List<GetOrderItemsQueryResult> OrderItems { get; set; }

    }
}

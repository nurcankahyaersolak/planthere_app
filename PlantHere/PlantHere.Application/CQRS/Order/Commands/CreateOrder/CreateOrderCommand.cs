using PlantHere.Application.CQRS.Address.Queries;
using PlantHere.Application.CQRS.Base;
using PlantHere.Application.CQRS.OrderItem.Queries.GetOrderItems;

namespace PlantHere.Application.CQRS.Order.Commands.CreateOrder
{
    public class CreateOrderCommand : CommandBase<CreateOrderCommandResult>
    {
        public DateTime CreatedDate { get; set; }

        public AddressQueryResult Address { get; set; }

        public string BuyerId { get; set; }

        public List<GetOrderItemsQueryResult> OrderItems { get; set; }

        public CreateOrderCommand(DateTime createdDate, AddressQueryResult address, string buyerId, List<GetOrderItemsQueryResult> orderItems)
        {
            CreatedDate = createdDate;
            Address = address;
            BuyerId = buyerId;
            OrderItems = orderItems;
        }
    }
}

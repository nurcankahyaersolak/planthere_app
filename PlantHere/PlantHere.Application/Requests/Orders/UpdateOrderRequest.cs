using PlantHere.Application.CQRS.Address.Queries;
using PlantHere.Application.CQRS.OrderItem.Queries.GetOrderItems;

namespace PlantHere.Application.Requests.Orders
{
    public class UpdateOrderRequest
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public AddressQueryResult? Address { get; set; }

        public string BuyerId { get; set; }

        public List<GetOrderItemsQueryResult> OrderItems { get; set; }

        public UpdateOrderRequest(int id, DateTime createdDate, AddressQueryResult? address, string buyerId, List<GetOrderItemsQueryResult> orderItems)
        {
            Id = id;
            CreatedDate = createdDate;
            Address = address;
            BuyerId = buyerId;
            OrderItems = orderItems;
        }
    }
}

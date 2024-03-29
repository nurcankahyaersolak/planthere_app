﻿using PlantHere.Application.CQRS.Address.Queries;
using PlantHere.Application.CQRS.OrderItem.Queries.GetOrderItems;

namespace PlantHere.Application.Requests.Orders
{
    public class CreateOrderRequest
    {
        public DateTime CreatedDate { get; set; }

        public AddressQueryResult Address { get; set; }

        public string BuyerId { get; set; }

        public List<GetOrderItemsQueryResult> OrderItems { get; set; }
    }
}

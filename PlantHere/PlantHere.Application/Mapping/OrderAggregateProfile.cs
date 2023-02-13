using AutoMapper;
using PlantHere.Application.CQRS.Address.Queries;
using PlantHere.Application.CQRS.Order.Commands.CreateOrder;
using PlantHere.Application.CQRS.Order.Quries.GetOrderById;
using PlantHere.Application.CQRS.Order.Quries.GetOrderByUserId;
using PlantHere.Application.CQRS.OrderItem.Queries.GetOrderItems;
using PlantHere.Domain.Aggregate.OrderAggregate.Entities;
using PlantHere.Domain.Aggregate.OrderAggregate.ValueObjects;

namespace PlantHere.Application.Mapping
{
    public class OrderAggregateProfile : Profile
    {
        public OrderAggregateProfile()
        {

            CreateMap<Order, CreateOrderCommandResult>().ReverseMap();
            CreateMap<Order, CreateOrderCommand>().ReverseMap();
            CreateMap<Order, GetOrderByIdQueryResult>().ReverseMap();
            CreateMap<Order, GetOrderByUserIdQueryResult>().ReverseMap();
            CreateMap<OrderItem, GetOrderItemsQueryResult>().ReverseMap();
            CreateMap<Address, AddressQueryResult>().ReverseMap();
        }
    }
}

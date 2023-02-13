using AutoMapper;
using PlantHere.Application.CQRS.Basket.Commands.CreateBasket;
using PlantHere.Application.CQRS.Basket.Queries.GetBasketByUserId;
using PlantHere.Application.CQRS.BasketItem.Queries.GetBasketItems;
using PlantHere.Domain.Aggregate.BasketAggregate.Entities;
using PlantHere.Domain.Aggregate.OrderAggregate.Entities;

namespace PlantHere.Application.Mapping
{
    public class BasketAggregateProfile : Profile
    {
        public BasketAggregateProfile()
        {
            CreateMap<BasketItem, GetBasketItemsQueryResult>().ReverseMap();
            CreateMap<Basket, GetBasketByUserIdQueryResult>().ReverseMap();
            CreateMap<Basket, CreateBasketCommand>().ReverseMap();
            CreateMap<BasketItem, OrderItem>().ReverseMap();
        }
    }
}

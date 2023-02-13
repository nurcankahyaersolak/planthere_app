using AutoMapper;
using PlantHere.Application.CQRS.BasketItem.Commands.CreateBasketItem;
using PlantHere.Application.CQRS.Product.Commands.CreateProduct;
using PlantHere.Application.CQRS.Product.Queries.GetProductByUniqueId;
using PlantHere.Application.CQRS.Product.Queries.GetProductsByPage;
using PlantHere.Application.CQRS.Product.Queries.GetProductsES;
using PlantHere.Domain.Aggregate.CategoryAggregate;

namespace PlantHere.Application.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, GetProductByUniqueIdQueryResult>().ReverseMap();
            CreateMap<Product, GetProductsByPageQueryResult>().ReverseMap();
            CreateMap<Product, CreateProductCommandResult>().ReverseMap();
            CreateMap<Product, CreateBasketItemCommand>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, GetProductsESQueryResult>().ReverseMap();
        }
    }
}

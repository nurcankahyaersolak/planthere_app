using AutoMapper;
using PlantHere.Application.CQRS.Category.Cammands.CreateCategory;
using PlantHere.Application.CQRS.Category.Cammands.DeleteCategory;
using PlantHere.Application.CQRS.Category.Cammands.UpdateCategory;
using PlantHere.Application.CQRS.Category.Queries.GetCategories;
using PlantHere.Domain.Aggregate.CategoryAggregate;



namespace PlantHere.Application.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, GetCategoriesQueryResult>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
            CreateMap<Category, DeleteCategoryCommand>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
        }
    }
}

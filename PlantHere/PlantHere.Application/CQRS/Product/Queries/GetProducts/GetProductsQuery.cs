using MediatR;
using PlantHere.Application.CQRS.Product.Queries.GetAllProducts;

namespace PlantHere.Application.CQRS.Product.Queries.GetAll
{
    public class GetProductsQuery : IRequest<IEnumerable<GetProductsQueryResult>>
    {
    }
}

using PlantHere.Application.CQRS.Base;

namespace PlantHere.Application.CQRS.Product.Queries.GetProductByUniqueId
{
    public class GetProductByUniqueIdQuery : QueryBase<GetProductByUniqueIdQueryResult>
    {
        public string UniqueId { get; set; }

        public GetProductByUniqueIdQuery(string uniqueId)
        {
            UniqueId = uniqueId;
        }
    }
}

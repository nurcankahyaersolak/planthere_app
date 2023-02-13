
using PlantHere.Application.CQRS.Base;

namespace PlantHere.Application.CQRS.Product.Queries.GetProductsByPage
{
    public class GetProductsByPageQuery : QueryBase<IEnumerable<GetProductsByPageQueryResult>>
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public GetProductsByPageQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
    }

}

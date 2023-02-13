using MediatR;

namespace PlantHere.Application.CQRS.Product.Queries.GetProductsES
{
    public class GetProductsESQuery : IRequest<List<GetProductsESQueryResult>>
    {
        public string keyword { get; set; }

        public GetProductsESQuery(string keyword)
        {
            this.keyword = keyword;
        }
    }
}

using MediatR;
using Nest;

namespace PlantHere.Application.CQRS.Product.Queries.GetProductsES
{
    public class GetProductsESQueryHandler : IRequestHandler<GetProductsESQuery, List<GetProductsESQueryResult>>
    {
        private readonly IElasticClient _elasticClient;

        public GetProductsESQueryHandler(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public async Task<List<GetProductsESQueryResult>> Handle(GetProductsESQuery request, CancellationToken cancellationToken)
        {
            var result = await _elasticClient.SearchAsync<GetProductsESQueryResult>(
                      s => s.Query(
                          q => q.QueryString(
                              d => d.Query('*' + request.keyword + '*')
                          )).Size(5));
            return result.Documents.ToList();
        }
    }
}

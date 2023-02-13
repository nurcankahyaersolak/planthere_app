using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using PlantHere.Application.CQRS.Product.Queries.GetAllProducts;
using PlantHere.Application.Settings;

namespace PlantHere.Infrastructure.Extensions.ElasticSearchExtensions
{
    public static class ElasticSearchExtensions
    {
        public static void AddElasticsearch(
            this IServiceCollection services, IConfiguration configuration)
        {

            var eSConfiguration = configuration.GetSection(nameof(ESConfiguration)).Get<ESConfiguration>();
            var url = eSConfiguration.Url;
            var defaultIndex = "products";

            var settings = new ConnectionSettings(new Uri(url))
                .PrettyJson()
                .DefaultIndex(defaultIndex);

            AddDefaultMappings(settings);

            var client = new ElasticClient(settings);

            services.AddSingleton<IElasticClient>(client);

            CreateIndex(client, defaultIndex);
        }

        private static void AddDefaultMappings(ConnectionSettings settings)
        {
            settings
                .DefaultMappingFor<GetProductsQueryResult>(m => m);
        }

        private static void CreateIndex(IElasticClient client, string indexName)
        {
            var createIndexResponse = client.Indices.Create(indexName,
                index => index.Map<GetProductsQueryResult>(x => x.AutoMap())
            );
        }
    }
}

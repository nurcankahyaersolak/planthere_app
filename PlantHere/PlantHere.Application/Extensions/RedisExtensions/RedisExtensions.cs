using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlantHere.Application.Settings;
using StackExchange.Redis;
using System.Net;

namespace PlantHere.Persistence.Extensions.RedisExtensions
{
    public static class RedisExtensions
    {
        public static void AddRedis(
         this IServiceCollection services, IConfiguration configuration)
        {
            var redisCongfiguration = configuration.GetSection(nameof(RedisConfiguration)).Get<RedisConfiguration>();

            services.AddStackExchangeRedisCache(options => options.Configuration = redisCongfiguration.Url);
        }

        public static List<RedisKey> GetRedisKeysByModelName(this IConfiguration configuration, string value)
        {
            var redisCongfiguration = configuration.GetSection(nameof(RedisConfiguration)).Get<RedisConfiguration>();

            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect($"{redisCongfiguration.Url},allowAdmin=true"))
            {
                IDatabase db = redis.GetDatabase();
                EndPoint endPoint = redis.GetEndPoints().First();
                var pattern = $"{value}:*";
                var keys = redis.GetServer(endPoint).Keys(pattern: pattern).ToList();
                return keys;
            }
        }
    }
}

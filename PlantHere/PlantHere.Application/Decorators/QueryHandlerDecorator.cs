using FluentValidation;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using PlantHere.Application.Extensions.StringExtensions;
using PlantHere.Application.Interfaces.Queries;
using PlantHere.Application.Settings;
using System.Collections;
using System.Globalization;
using System.Text;
using System.Text.Json;

namespace PlantHere.Application.Decorators
{
    internal sealed class QueryHandlerDecorator<TRequest, TResult> : IQueryHandler<TRequest, TResult>
    where TRequest : IQuery<TResult>
    {
        private readonly IRequestHandler<TRequest, TResult> _decorated;

        private readonly IDistributedCache _distributedCache;

        private readonly IConfiguration _configuration;

        private bool isCacheable = false;

        private TimeSpan _expiration;

        public QueryHandlerDecorator(IRequestHandler<TRequest, TResult> decorated, IDistributedCache distributedCache,IConfiguration configuration)
        {
            _decorated = decorated;
            _distributedCache = distributedCache;
            _configuration = configuration;
            isCacheable = this._decorated.GetType().GetInterfaces().Any(x => x.Name == nameof(IQueryCacheable));
            if (isCacheable) _expiration = GetExpiration(this._decorated); 
        }

        public async Task<TResult> Handle(TRequest query, CancellationToken cancellationToken)
        {
            if (this.isCacheable)
            {
                var cacheKey = this.GetCacheKey(query);
                var value = await _distributedCache.GetAsync(cacheKey);
                if (value == null)
                {
                    var result = await _decorated.Handle(query, cancellationToken);
                    byte[] objectToCache = JsonSerializer.SerializeToUtf8Bytes(result);
                    await _distributedCache.SetAsync(cacheKey, objectToCache, new DistributedCacheEntryOptions().SetSlidingExpiration(_expiration));
                    value = await _distributedCache.GetAsync(cacheKey);
                }

                var jsonToDeserialize = Encoding.UTF8.GetString(value);
                var cachedResult = JsonSerializer.Deserialize<TResult>(jsonToDeserialize);
                return cachedResult;
            }
            else
            {
                return await _decorated.Handle(query, cancellationToken);
            }
        }

        private string GetCacheKey(TRequest request)
        {
            var modelName = request.GetType().FullName?.GetModelName();

            var cacheKey = CreateCacheKey(request);

            var cacheKeyWithQueryName = string.IsNullOrWhiteSpace(cacheKey)
                ? $"{this._decorated.GetType().Name}"
                : $"{this._decorated.GetType().Name}:{cacheKey}";

            return string.IsNullOrWhiteSpace(modelName)
                ? $"{cacheKeyWithQueryName}"
                : $"{modelName}:{cacheKeyWithQueryName}";
        }

        public static string CreateCacheKey(object obj, string propName = null)
        {
            var sb = new StringBuilder();
            if (obj.GetType().IsValueType || obj is string)
            {
                _ = sb.AppendFormat(CultureInfo.CurrentCulture, "{0}_{1}|", propName, obj);
            }
            else
            {
                var properties = obj.GetType().GetProperties().Where(x => x.Name != "RequestId").ToArray();
                if (!properties.Any())
                {
                    return default;
                }
                foreach (var prop in properties)
                {
                    if (typeof(IEnumerable).IsAssignableFrom(prop.PropertyType))
                    {
                        var get = prop.GetGetMethod();
                        if (!get.IsStatic && get.GetParameters().Length == 0)
                        {
                            var collection = (IEnumerable)get.Invoke(obj, null);
                            if (collection != null)
                            {
                                foreach (var o in collection)
                                {
                                    _ = sb.Append(CreateCacheKey(o, prop.Name));
                                }
                            }
                        }
                    }
                    else
                    {
                        _ = sb.AppendFormat(CultureInfo.CurrentCulture, "{0}{1}_{2}|", propName, prop.Name, prop.GetValue(obj, null));
                    }
                }
            }
            return sb.ToString();
        }

        public TimeSpan GetExpiration(object obj)
        {
            var redisCongfiguration = _configuration.GetSection(nameof(RedisConfiguration)).Get<RedisConfiguration>();
            _expiration = TimeSpan.FromSeconds(redisCongfiguration.Expiration);
            
            if (obj.GetType().GetProperties() != null)
            {
                var value =  obj.GetType().GetProperties().FirstOrDefault(x => x.Name == "Expiration")?.GetValue(obj);
                if (value != null) _expiration = (TimeSpan)value;
            }
            return _expiration;
        }
    }
}
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlantHere.Application.Decorators;
using PlantHere.Application.Pipelines;
using PlantHere.Persistence.Extensions.RedisExtensions;
using System.Reflection;


namespace PlantHere.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection serviceCollection, IConfiguration configuration = null)
        {
            // MediatR
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());

            // Auto Mapper
            serviceCollection.AddAutoMapper(typeof(ServiceRegistration));

            // Redis
            serviceCollection.AddRedis(configuration);

            // Validators
            serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            // Decorator
            serviceCollection.Decorate(typeof(IRequestHandler<,>), typeof(CommandHandlerDecorator<,>));
            serviceCollection.Decorate(typeof(IRequestHandler<,>), typeof(QueryHandlerDecorator<,>));
        }
    }
}

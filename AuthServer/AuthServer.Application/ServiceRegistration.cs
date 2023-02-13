using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace AuthServer.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection serviceCollection, IConfiguration configuration = null)
        {

            // MediatR
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}

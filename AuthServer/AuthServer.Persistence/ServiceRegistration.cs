using AuthServer.Application.Configurations;
using AuthServer.Application.Interfaces.Repositories;
using AuthServer.Application.Interfaces.Services;
using AuthServer.Persistence.Repositories;
using AuthServer.Persistence.Services;
using AuthServer.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UdemyAuthServer.Core.UnitOfWork;

namespace AuthServer.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection serviceCollection, IConfiguration configuration = null)
        {

            // Db

            serviceCollection.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration?.GetConnectionString("SQLConnection").Trim(), option =>
                {
                    option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext))?.GetName().Name);
                });
            });

            //CAP

            var rabbitMQConfiguration = configuration.GetSection("RabbitMQConfiguration").Get<RabbitMQConfiguration>();

            serviceCollection.AddCap(options =>
            {
                options.UseEntityFramework<AppDbContext>();
                options.UseSqlServer(configuration?.GetConnectionString("SQLConnection"));
                options.UseRabbitMQ(options =>
                {
                    options.ConnectionFactoryOptions = options =>
                    {
                        
                        options.Ssl.Enabled = false;
                        options.HostName = rabbitMQConfiguration.HostName;
                        options.UserName = rabbitMQConfiguration.UserName;
                        options.Password = rabbitMQConfiguration.Password;
                        options.Port = rabbitMQConfiguration.Port;
                    };

                });
                options.UseDashboard(o => o.PathMatch = "/cap");
            });

            // Service

            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<ITokenService, TokenService>();
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlantHere.Application.Settings;
using PlantHere.Persistence;

namespace PlantHere.Infrastructure.Extensions.RabbitMQExtensions
{
    public static class AddRabbitMQExtensions
    {
        public static void AddRabbitMQ(
          this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitMQConfiguration = configuration.GetSection(nameof(RabbitMQConfiguration)).Get<RabbitMQConfiguration>();

            services.AddCap(options =>
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
        }
    }
}

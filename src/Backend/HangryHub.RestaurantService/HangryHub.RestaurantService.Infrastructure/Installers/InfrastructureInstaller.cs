using HangryHub.RestaurantService.Domain.Common.Installers;
using HangryHub.RestaurantService.Infrastructure.Common.Persistance.EntityFrameworkCore;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HangryHub.RestaurantService.Infrastructure.Installers;

public static class InfrastructureInstaller
{
    public static void InstallInfrastructure(this IServiceCollection services, string connectionString)
    {
        connectionString = "Data Source=LocalDatabase.db";  //TODO: CHANGE

        services.AddDbContext<RestaurantServiceDbContext>(options =>
        { 
            options.UseSqlite(connectionString);
        });

        services.InstallRegisterAttribute(System.Reflection.Assembly.GetExecutingAssembly());

        var rabbitMqHost = Environment.GetEnvironmentVariable("RABBITHOST");
        if (rabbitMqHost == null)
        {
            rabbitMqHost = "localhost";
        }

        // rabbit mq
        services.AddMassTransit(x =>
        {
            // x.AddConumer(...) 
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(rabbitMqHost, h => {

                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ConfigureEndpoints(context);
            });
        });
    }
}

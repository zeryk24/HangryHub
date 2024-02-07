using HangryHub.MainService.Application;
using HangryHub.MainService.Application.Order.Producers.CreateOrder;
using HangryHub.MainService.Application.Repository;
using HangryHub.MainService.Application.Services;
using HangryHub.MainService.Infrastructure.Repository;
using HangryHub.MainService.Infrastructure.Services;
using MassTransit;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static void InstallInfrastructure(IServiceCollection services)
        {
            ApplicationDependencyInjection.InstallApplication(services);

            var builder = new SqliteConnectionStringBuilder("Data Source=main_test_v1.db");
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;

            builder.DataSource = Path.Combine(baseDir, builder.DataSource);

            services.AddDbContext<MainDBContext>((options) =>
            {
                options.UseSqlite(builder.ToString());
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.AddScoped<IRepository<Domain.RestaurantAggregate.Restaurant>, EFRepository<Domain.RestaurantAggregate.Restaurant>>();
            services.AddScoped<IRepository<Domain.RestaurantAggregate.Entities.RestaurantItem>, EFRepository<Domain.RestaurantAggregate.Entities.RestaurantItem>>();
            services.AddScoped<IRestaurantAggregateRepository, RestaurantAggregateRepository>();
            services.AddScoped<IShoppingCartAggregateRepository, ShoppingCartAggregateRepository>();
            services.AddScoped<IShoppingCartCalculationService, ShoppingCartCalculationService>();
            /*services.AddTransient<IListAvaiableQueryService, ListAvaiableQueryService>();
            services.AddTransient<IDeliveryStateService, DeliveryStateService>();*/

            SetUpRabbitMq(services);
        }

        private static void SetUpRabbitMq(IServiceCollection services)
        {
            var rabbitMqHost = Environment.GetEnvironmentVariable("RABBITHOST");
            if (rabbitMqHost == null)
            {
                rabbitMqHost = "localhost";
            }

            // rabbit mq
            services.AddMassTransit(x =>
            {
                // add from assembly, alternative is to add every consumer manually
                x.AddConsumers(typeof(CreateOrderProducer).Assembly);
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
}

using HangryHub.OrderService.Core.Interfaces;
using HangryHub.OrderService.Core.OrderAggregate;
using HangryHub.OrderService.Infrastructure.Data;
using HangryHub.OrderService.Infrastructure.Data.Order.Services;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HangryHub.OrderService.Infrastructure
{
    public static class InfrastructureInstaller
    {
        public static void InstallInfrastructure(IServiceCollection services)
        {
            string connection_string = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=HangryHub.OrderService;";
            System.IO.Directory.CreateDirectory("sqlitedb");

            //services.AddDbContext<OrderServiceContext>(options => options.UseSqlite(connection_string));
            services.AddDbContext<OrderServiceContext>((options) =>
            {
                options.UseSqlite("Filename=sqlitedb/order.db;");
            }
            );

            services.AddTransient<DbContext, OrderServiceContext>();
            services.AddTransient<IRepository<Core.OrderAggregate.Order>, EFRepository<Core.OrderAggregate.Order>>();
            services.AddTransient<IGetOrderByIdService, GetOrderByIdService>();
            services.AddTransient<ICreateOrderService, CreateOrderService>();
            services.AddTransient<IAcceptOrderService, AcceptOrderService>();
            services.AddTransient<IDeclineOrderService, DeclineOrderService>();
            services.AddTransient<IReadyOrderService, ReadyOrderService>();
            services.AddTransient<ICheckStatusOrderService, CheckStatusOrderService>();

            // rabbit mq
            services.AddMassTransit(x =>
            {
                // x.AddConumer(...) 
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("rabbitmq", h => {

                        h.Username("guest");
                        h.Password("guest");
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });
        }

        public static void ConfigureInfrastructure(OrderServiceContext? context, bool isDeveloplment)
        {
            if (context == null)
            {
                return;
            }

            context.Database.Migrate();
        }
    }
}

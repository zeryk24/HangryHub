using HangryHub.OrderService.Core.Interfaces;
using HangryHub.OrderService.Core.OrderAggregate;
using HangryHub.OrderService.Core.OrderAggregate.Entities.CouponEntity;
using HangryHub.OrderService.Core.OrderAggregate.ValueObjects;
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
            services.AddTransient<IRepository<Core.OrderAggregate.Order>, Data.Order.OrderRepository>();
            services.AddTransient<IGetOrderByIdService, GetOrderByIdService>();
            services.AddTransient<ICreateOrderService, CreateOrderService>();
            services.AddTransient<IAcceptOrderService, AcceptOrderService>();
            services.AddTransient<IDeclineOrderService, DeclineOrderService>();
            services.AddTransient<IReadyOrderService, ReadyOrderService>();
            services.AddTransient<ICheckStatusOrderService, CheckStatusOrderService>();
            services.AddTransient<IOrderStatusChangeService, OrderStatusChangeService>();
            services.AddTransient<IGetByRestaurantService, GetByRestaurantService>();

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

        public static void ConfigureInfrastructure(OrderServiceContext? context, bool isDeveloplment)
        {
            if (context == null)
            {
                return;
            }

            context.Database.Migrate();

            if (isDeveloplment)
            {
                var coupon1 = new Coupon(
                    new Core.OrderAggregate.Entities.CouponEntity.ValueObjects.CouponName("Black friday"),
                    new Core.OrderAggregate.Entities.CouponEntity.ValueObjects.CouponPrice(5)
                    );

                var items = new List<Core.OrderAggregate.Entities.OrderItemEntity.OrderItem>()
                {
                    new Core.OrderAggregate.Entities.OrderItemEntity.OrderItem(
                        new Core.OrderAggregate.Entities.OrderItemEntity.ValueObjects.RestaurantItemId(Guid.NewGuid()),
                        new Core.OrderAggregate.Entities.OrderItemEntity.ValueObjects.ItemName("Watter"),
                        new Core.OrderAggregate.Entities.OrderItemEntity.ValueObjects.ItemQuantity(5),
                        new Core.OrderAggregate.Entities.OrderItemEntity.ValueObjects.ItemPrice(7),
                        new List<Core.OrderAggregate.Entities.IngredientEntity.ExtraIngredient>() {
                            new Core.OrderAggregate.Entities.IngredientEntity.ExtraIngredient(
                                new Core.OrderAggregate.Entities.IngredientEntity.ValueObjects.IngredientName("Bubble"),
                                new Core.OrderAggregate.Entities.IngredientEntity.ValueObjects.IngredientQuantity(50)
                                )
                        }
                        )
                };

                var order1 = new Order(
                    new Price(10),
                    new Accept(true, DateTime.Now),
                    new Decline(false, null),
                    new Ready(false, null),
                    new Coupon(
                    new Core.OrderAggregate.Entities.CouponEntity.ValueObjects.CouponName("Black friday"),
                    new Core.OrderAggregate.Entities.CouponEntity.ValueObjects.CouponPrice(5)
                    ),
                    new UserId(Guid.NewGuid()),
                    items,
                    new RestaurantId(Guid.Parse("e728e5ea-bf6f-4600-9d59-a286b7be767c"))
                    );

                context.Add(order1);
                context.SaveChanges();
            }
        }
    }
}

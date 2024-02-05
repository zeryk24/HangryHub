﻿using HangryHub.DeliveryService.Application.Common;
using HangryHub.DeliveryService.Application.Delivery.Consumers.TestMessageConsumer;
using HangryHub.DeliveryService.Application.Delivery.Queries.GetState;
using HangryHub.DeliveryService.Application.Delivery.Queries.ListAvaiable;
using HangryHub.DeliveryService.Domain.DeliveryAggregate;
using HangryHub.DeliveryService.Domain.DeliveryAggregate.Entities;
using HangryHub.DeliveryService.Domain.DeliveryAggregate.Enums;
using HangryHub.DeliveryService.Domain.DeliveryAggregate.ValueObjects;
using HangryHub.DeliveryService.Infrastructure.Common.Data;
using HangryHub.DeliveryService.Infrastructure.Delivery.Data.QueryService;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace HangryHub.DeliveryService.Infrastructure
{
    public static class InfrastructureInstaller
    {
        public static void InstallInfrastructure(IServiceCollection services)
        {
            // TODO: temporary, refactor!

            string connection_string = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=HangryHub.DeliveryService;";
            System.IO.Directory.CreateDirectory("sqlitedb");
            services.AddDbContext<DeliveryServiceContext>((options) =>
            {
                options.UseSqlite("Filename=sqlitedb/delivery.db;");
                //options.UseSqlServer(connection_string);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }
            );
            
            services.AddTransient<IRepository<Domain.DeliveryAggregate.Delivery>, EFRepository<Domain.DeliveryAggregate.Delivery>>();
            services.AddTransient<IListAvaiableQueryService, ListAvaiableQueryService>();
            services.AddTransient<IDeliveryStateService, DeliveryStateService>();

            var rabbitMqHost = Environment.GetEnvironmentVariable("RABBITHOST");
            if (rabbitMqHost == null)
            {
                rabbitMqHost = "localhost";
            }

            // rabbit mq
            services.AddMassTransit(x =>
            {
                // add from assembly, alternative is to add every consumer manually
                x.AddConsumers(typeof(TestMessageConsumer).Assembly);
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

        public static void ConfigureInfrastructure(DeliveryServiceContext? context, bool isDeveloplment)
        {
            if (context == null) return;

            if (isDeveloplment) context.Database.EnsureDeleted();

            context.Database.Migrate();

            if (isDeveloplment)
            {
                context.Add(
                            new Domain.DeliveryAggregate.Delivery(
                            Guid.NewGuid(),
                            new Restaurant(
                                new RestaurantId(Guid.NewGuid()),
                                new RestaurantContact("777666777", "777666445"),
                                new RestaurantLocation("Ulice 1", "Az v druhem patre!")
                            ),
                            new Order(
                                new OrderId(Guid.NewGuid()),
                                OrderState.Accepted
                            ),
                            new Customer(
                                new CustomerId(Guid.NewGuid()),
                                new CustomerContact("555666555", "777888555"),
                                new CustomerDeliveryLocation("Daleka ulice 35", "Nechte jidlo pred domem", Domain.DeliveryAggregate.Enums.CustomerLocationType.Home)
                            ),
                            null,
                            DeliveryState.NotAsigned)

                    );
                context.SaveChanges();
            }
        }
    
    }
}

using HangryHub.DeliveryService.Application.Common;
using HangryHub.DeliveryService.Application.Delivery.ListAvaiable;
using HangryHub.DeliveryService.Domain.DeliveryAggregate;
using HangryHub.DeliveryService.Infrastructure.Common.Data;
using HangryHub.DeliveryService.Infrastructure.Delivery.Data.QueryService;
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
            services.AddDbContext<DeliveryServiceContext>(options => options.UseSqlServer(connection_string));
            
            
            services.AddTransient<IRepository<Domain.DeliveryAggregate.Delivery>, EFRepository<Domain.DeliveryAggregate.Delivery>>();
            services.AddTransient<IListAvaiableQueryService, ListAvaiableQueryService>();



        }
    
    }
}

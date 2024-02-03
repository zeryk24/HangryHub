using HangryHub.MainService.Application;
using HangryHub.MainService.Application.Repository;
using HangryHub.MainService.Infrastructure.Repository;
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

            services.AddDbContext<MainDBContext>((options) =>
            {
                options.UseSqlite("Filename=sqlitedb/test_db1.db;");
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.AddTransient<IRepository<Domain.RestaurantAggregate.Restaurant>, EFRepository<Domain.RestaurantAggregate.Restaurant>>();
            services.AddTransient<IRepository<Domain.RestaurantAggregate.Entities.RestaurantItem>, EFRepository<Domain.RestaurantAggregate.Entities.RestaurantItem>>();
            services.AddTransient<IRepository<Domain.RestaurantAggregate.Entities.RestaurantLocation>, EFRepository<Domain.RestaurantAggregate.Entities.RestaurantLocation>>();
            /*services.AddTransient<IListAvaiableQueryService, ListAvaiableQueryService>();
            services.AddTransient<IDeliveryStateService, DeliveryStateService>();*/
        }
    }
}

using HangryHub.DeliveryService.Application.Common;
using HangryHub.DeliveryService.Domain.DeliveryAggregate;
using HangryHub.DeliveryService.Infrastructure.Data.Common;

using Microsoft.Extensions.DependencyInjection;

namespace HangryHub.DeliveryService.Infrastructure
{
    public static class InfrastructureInstaller
    {
        public static void InstallInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Delivery>, EFRepository<Delivery>>();
        }
    
    }
}

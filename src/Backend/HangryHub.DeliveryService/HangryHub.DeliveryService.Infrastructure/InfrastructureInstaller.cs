using HangryHub.DeliveryService.Application.Common;
using HangryHub.DeliveryService.Domain.Delivery;
using HangryHub.DeliveryService.Infrastructure.Data.Common;

using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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

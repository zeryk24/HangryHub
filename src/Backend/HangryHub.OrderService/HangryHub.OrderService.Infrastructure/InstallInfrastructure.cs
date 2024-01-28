using HangryHub.OrderService.Core.Interfaces;
using HangryHub.OrderService.Infrastructure.Data.Order.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HangryHub.OrderService.Infrastructure
{
    public static class InfrastructureInstaller
    {
        public static void InstallInfrastructure(IServiceCollection services)
        {
            services.AddTransient<IGetOrderByIdService, GetOrderByIdService>();
        }
    }
}

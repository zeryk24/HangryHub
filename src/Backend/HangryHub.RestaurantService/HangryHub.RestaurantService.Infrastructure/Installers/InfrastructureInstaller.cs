using HangryHub.RestaurantService.Domain.Common.Installers;
using HangryHub.RestaurantService.Infrastructure.Common.Persistance.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HangryHub.RestaurantService.Infrastructure.Installers;

public static class InfrastructureInstaller
{
    public static void InstallInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<RestaurantServiceDbContext>();

        services.InstallRegisterAttribute(System.Reflection.Assembly.GetExecutingAssembly());
    }
}

using HangryHub.RestaurantService.Domain.Common.Installers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HangryHub.RestaurantService.Domain.Installers;

public static class DomainInstaller
{
    public static void InstallDomain(this IServiceCollection services)
    {
        services.InstallRegisterAttribute(Assembly.GetExecutingAssembly());
    }
}


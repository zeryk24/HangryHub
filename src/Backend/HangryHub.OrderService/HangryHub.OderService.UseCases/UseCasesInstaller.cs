using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HangryHub.OderService.UseCases
{
    public static class UseCasesInstaller
    {
        public static void InstallApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.InstallMediatr(assembly);
        }

        private static void InstallMediatr(this IServiceCollection services, Assembly assembly)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(assembly);
            });
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.DeliveryService.Application
{
    public static class ApplicationInstaller
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

using HangryHub.RestaurantService.Infrastructure.Installers;
using HangryHub.RestaurantService.Application.Installers;
using HangryHub.RestaurantService.Domain.Installers;

var app = await PresentationInstaller.InstallPresentationAsync(args, options =>
{
    options.InstallDomain();
    options.InstallApplication();
    options.InstallInfrastructure("");
});

await PresentationInstaller.RunAsync(app);

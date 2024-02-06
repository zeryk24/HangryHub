using FastEndpoints;
using FastEndpoints.Swagger;
using HangryHub.RestaurantService.Presentation.Common.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class PresentationInstaller
{
    public static Task<WebApplicationBuilder> InstallPresentationAsync(string[] args, Action<IServiceCollection> options)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        options.Invoke(builder.Services);

        builder.Services.AddFastEndpoints().SwaggerDocument();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return Task.FromResult(builder);
    }

    public static Task RunAsync(WebApplicationBuilder builder)
    {
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment() || true)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseExceptionHanlingMiddleware();

        app.UseHttpsRedirection();

        app.UseFastEndpoints().UseSwaggerGen();

        return app.RunAsync();
    }
}

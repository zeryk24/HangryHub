using HangryHub.DeliveryService.Application;
using HangryHub.DeliveryService.Infrastructure;
using HangryHub.DeliveryService.Infrastructure.Common.Data;

using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
InfrastructureInstaller.InstallInfrastructure(builder.Services);
ApplicationInstaller.InstallApplication(builder.Services);




builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}


 


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//// todo: refactor somewhere else?
using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetService<DeliveryServiceContext>();
InfrastructureInstaller.ConfigureInfrastructure(context, app.Environment.IsDevelopment());

app.Run();

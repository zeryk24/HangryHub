using HangryHub.OderService.UseCases;
using HangryHub.OrderService.Infrastructure;
using HangryHub.OrderService.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

InfrastructureInstaller.InstallInfrastructure(builder.Services);
UseCasesInstaller.InstallApplication(builder.Services);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || true)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetService<OrderServiceContext>();
InfrastructureInstaller.ConfigureInfrastructure(context, app.Environment.IsDevelopment());

app.Run();

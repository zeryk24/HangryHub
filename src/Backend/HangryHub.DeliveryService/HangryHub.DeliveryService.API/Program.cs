using HangryHub.DeliveryService.Application;
using HangryHub.DeliveryService.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
InfrastructureInstaller.InstallInfrastructure(builder.Services);
ApplicationInstaller.InstallApplication(builder.Services);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.Run();

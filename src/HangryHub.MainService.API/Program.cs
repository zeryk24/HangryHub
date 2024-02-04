using HangryHub.MainService.Infrastructure;
using HangryHub.MainService.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

InfrastructureDependencyInjection.InstallInfrastructure(builder.Services);

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


if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetService<MainDBContext>();

    if (context == null)
    {
        throw new ArgumentException("DI was not able to resolve DBContext. This seems like a mojor issue ... Thank god that we are in the development ;)");
    }

    await DatabaseSeeder.SeedDatabaseAsync(context);
}

app.Run();

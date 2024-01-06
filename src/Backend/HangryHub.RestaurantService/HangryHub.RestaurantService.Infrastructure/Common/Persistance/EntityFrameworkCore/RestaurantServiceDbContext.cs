using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HangryHub.RestaurantService.Infrastructure.Common.Persistance.EntityFrameworkCore;

public class RestaurantServiceDbContext : DbContext
{
    public RestaurantServiceDbContext() {}

    public RestaurantServiceDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}

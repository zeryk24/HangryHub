using Microsoft.EntityFrameworkCore;

namespace HangryHub.OrderService.Infrastructure.Data
{
    public class OrderServiceContext : DbContext
    {
        public DbSet<Core.OrderAggregate.Order> Orders { get; set; }

        public OrderServiceContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderServiceContext).Assembly);

            var order = modelBuilder.Entity<Core.OrderAggregate.Order>();
            order.HasKey(o => o.Id);

            var price = order.OwnsOne(o => o.PriceEuro);
            var accept = order.OwnsOne(o => o.OrderAccepted);
            var decline = order.OwnsOne(o => o.OrderDeclined);
        }
    }
}

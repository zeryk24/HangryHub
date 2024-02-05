using HangryHub.OrderService.Core.OrderAggregate.Entities.CouponEntity;
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
            var ready = order.OwnsOne(o => o.OrderReady);

            var coupon = modelBuilder.Entity<Coupon>();
            
            coupon.HasKey(c => c.Id);
            coupon.OwnsOne(c => c.Price);
            coupon.OwnsOne(c => c.Name);
            order.HasOne(o => o.Coupon);
        }
    }
}

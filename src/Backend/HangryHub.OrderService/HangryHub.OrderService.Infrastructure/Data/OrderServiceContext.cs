using HangryHub.OrderService.Core.OrderAggregate.Entities.CouponEntity;
using HangryHub.OrderService.Core.OrderAggregate.Entities.IngredientEntity;
using HangryHub.OrderService.Core.OrderAggregate.Entities.OrderItemEntity;
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
            order.OwnsOne(o => o.UserId);

            var coupon = modelBuilder.Entity<Coupon>();
            
            coupon.HasKey(c => c.Id);
            coupon.OwnsOne(c => c.Price);
            coupon.OwnsOne(c => c.Name);
            order.HasOne(o => o.Coupon);

            var items = modelBuilder.Entity<OrderItem>();
            order.HasMany(o => o.Items);

            items.HasKey(i => i.Id);
            items.OwnsOne(i => i.Name);
            items.OwnsOne(i => i.RestaurantItemId);
            items.OwnsOne(i => i.Quantity);
            items.OwnsOne(i => i.Price);

            var ingredients = modelBuilder.Entity<ExtraIngredient>();
            items.HasMany(i => i.ExtraIngredients);

            ingredients.OwnsOne(i => i.Quantity);
            ingredients.OwnsOne(i => i.Name);
            ingredients.HasKey(i => i.Id);
        }
    }
}

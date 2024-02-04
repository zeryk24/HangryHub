using HangryHub.MainService.Domain.ShoppingCartAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HangryHub.MainService.Domain.ShoppingCartAggregate.ValueObjects;
using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;

namespace HangryHub.MainService.Infrastructure.Configuration.ShoppingCartAggregateConfigs
{
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.ToTable("ShoppingCarts");

            builder.HasKey(sc => sc.Id);

            builder.Property(sc => sc.Id)
                   .HasConversion(id => id.Value, value => new ShoppingCartId(value))
                   .HasColumnName("ShoppingCartId");

            builder.Property(sc => sc.CustomerId)
                   .HasConversion(id => id.Value, value => new CustomerId(value))
                   .HasColumnName("CustomerId");

            builder.Property(sc => sc.RestaurantId)
                   .HasConversion(id => id.Value, value => new RestaurantId(value))
                   .HasColumnName("RestaurantId");

            builder.Property(sc => sc.SelectedDeliveryDataId)
                   .HasConversion(id => id.Value, value => new DeliveryDataId(value))
                   .HasColumnName("SelectedDeliveryDataId")
                   .IsRequired(false); // its nullable

            builder.Property(sc => sc.IsActive).IsRequired();
            builder.Property(sc => sc.CreatedDate).IsRequired();
            builder.Property(sc => sc.LastUpdatedDate).IsRequired();

            builder.HasOne(sc => sc.SelectedDeliveryData)
                   .WithOne()
                   .HasForeignKey<ShoppingCart>(sc => sc.SelectedDeliveryDataId);

            builder.Navigation(sc => sc.Items)
                   .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}

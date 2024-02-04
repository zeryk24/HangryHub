using HangryHub.MainService.Domain.RestaurantAggregate.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;

namespace HangryHub.MainService.Infrastructure.Configuration
{
    public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .HasConversion(id => id.Value, value => new CouponId(value));

            builder.Property(c => c.RestaurantId)
                   .HasConversion(id => id.Value, value => new RestaurantId(value));

            builder.HasOne(c => c.Restaurant)
                   .WithMany(r => r.AvailableCoupons)
                   .HasForeignKey(c => c.RestaurantId);

            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Price).HasColumnType("decimal(18,2)");
            builder.Property(c => c.ExpirationDateTime).IsRequired();
        }
    }

}

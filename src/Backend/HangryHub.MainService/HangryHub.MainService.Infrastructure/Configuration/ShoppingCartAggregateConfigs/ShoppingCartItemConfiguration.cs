using HangryHub.MainService.Domain.ShoppingCartAggregate.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using HangryHub.MainService.Domain.ShoppingCartAggregate.ValueObjects;

namespace HangryHub.MainService.Infrastructure.Configuration.ShoppingCartAggregateConfigs
{
    public class ShoppingCartItemConfiguration : IEntityTypeConfiguration<ShoppingCartItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            builder.ToTable("ShoppingCartItems");

            builder.HasKey(sci => sci.Id);

            builder.Property(sci => sci.Id)
                   .HasConversion(id => id.Value, value => new ShoppingCartItemId(value))
                   .HasColumnName("ShoppingCartItemId");

            builder.Property(sci => sci.ShoppingCartId)
                   .HasConversion(id => id.Value, value => new ShoppingCartId(value))
                   .HasColumnName("ShoppingCartId");

            builder.Property(sci => sci.RestaurantItemId)
                   .HasConversion(id => id.Value, value => new RestaurantItemId(value))
                   .HasColumnName("RestaurantItemId");


            builder.Property(sci => sci.ItemName).IsRequired();
            builder.Property(sci => sci.ItemDescription).IsRequired();
            builder.Property(sci => sci.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(sci => sci.Quantity).IsRequired();

            builder.HasOne(sci => sci.ShoppingCart)
                   .WithMany(sc => sc.Items)
                   .HasForeignKey(sci => sci.ShoppingCartId);
        }
    }
}

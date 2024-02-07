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
    public class SelectedAdditionalIngredientConfiguration : IEntityTypeConfiguration<SelectedAdditionalIngredient>
    {
        public void Configure(EntityTypeBuilder<SelectedAdditionalIngredient> builder)
        {
            builder.ToTable("SelectedAdditionalIngredients");

            // Primary Key
            builder.HasKey(sai => sai.Id);

            // ID conversion
            builder.Property(sai => sai.Id)
                   .HasConversion(id => id.Value, value => new SelectedAdditionalIngredientId(value))
                   .HasColumnName("SelectedAdditionalIngredientId");

            // Configure the foreign key for ShoppingCartItem
            builder.Property(sai => sai.ShoppingCartItemId)
                   .HasConversion(id => id.Value, value => new ShoppingCartItemId(value))
                   .HasColumnName("ShoppingCartItemId");

            // Configure the foreign key for AdditionalIngredient
            builder.Property(sai => sai.AdditionalIngredientId)
                   .HasConversion(id => id.Value, value => new AdditionalIngredientId(value))
                   .HasColumnName("AdditionalIngredientId");

            // Other properties
            builder.Property(sai => sai.Name).IsRequired();
            builder.Property(sai => sai.Quantity).IsRequired();
            builder.Property(sai => sai.Price).IsRequired();

            builder.HasOne(sci => sci.ShoppingCartItem)
                   .WithMany(sc => sc.SelectedAdditionalIngredients)
                   .HasForeignKey(sci => sci.ShoppingCartItemId);
        }
    }
}

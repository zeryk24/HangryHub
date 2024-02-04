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
    public class AdditionalIngredientConfiguration : IEntityTypeConfiguration<AdditionalIngredient>
    {
        public void Configure(EntityTypeBuilder<AdditionalIngredient> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                   .HasConversion(id => id.Value, value => new AdditionalIngredientId(value));

            builder.Property(i => i.Name).IsRequired();

            builder.Property(i => i.RestaurantItemId)
                   .HasConversion(id => id.Value, value => new RestaurantItemId(value));

            builder.HasOne(i => i.RestaurantItem)
                   .WithMany(i => i.AdditionalIngredients)
                   .HasForeignKey(i => i.RestaurantItemId);

            builder.Property(ai => ai.Price).IsRequired().HasColumnType("decimal(18,2)");
        }
    }
}

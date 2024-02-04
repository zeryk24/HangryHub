using HangryHub.MainService.Domain.RestaurantAggregate.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using HangryHub.MainService.Infrastructure.Configuration.Constants;

namespace HangryHub.MainService.Infrastructure.Configuration
{
    public class RestaurantItemConfiguration : IEntityTypeConfiguration<RestaurantItem>
    {
        public void Configure(EntityTypeBuilder<RestaurantItem> builder)
        {
            builder.ToTable(ConfigurationConstants.RestaurantsItemTableName);

            // Primary Key
            builder.HasKey(ri => ri.Id);

            // ID conversion
            builder.Property(ri => ri.Id)
                   .HasConversion(id => id.Value, value => new RestaurantItemId(value))
                   .HasColumnName(ConfigurationConstants.RestaurantsItemIdColumnName);

            // Configure the foreign key for Restaurant
            builder.Property(ri => ri.RestaurantId)
                   .HasConversion(id => id.Value, value => new RestaurantId(value))
                   .HasColumnName(ConfigurationConstants.RestaurantIdColumnName);

            // Configure relationships
            builder.HasOne(ri => ri.Restaurant)
                   .WithMany(r => r.Items)
                   .HasForeignKey(ri => ri.RestaurantId);

            // Other properties
            builder.Property(ri => ri.Name).IsRequired();
            builder.Property(ri => ri.Description).IsRequired();
            builder.Property(ri => ri.Price).IsRequired();

            // Explicit configuration for Ingredients relationship
            builder.Navigation(ri => ri.Ingredients)
                   .UsePropertyAccessMode(PropertyAccessMode.Property);

            // Explicit configuration for AdditionalIngredients relationship using shadow property
            builder.Navigation(ri => ri.AdditionalIngredients)
                   .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }

}

using HangryHub.MainService.Domain.RestaurantAggregate;
using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using HangryHub.MainService.Infrastructure.Configuration.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Infrastructure.Configuration.RestaurantAggregateConfigs
{
    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.ToTable(ConfigurationConstants.RestaurantsTableName);

            // Configure the primary key
            builder.HasKey(r => r.Id);

            // Configure the ID with conversion
            builder.Property(r => r.Id)
                   .HasConversion(id => id.Value, value => new RestaurantId(value))
                   .HasColumnName(ConfigurationConstants.RestaurantIdColumnName);

            // Configure the Name
            builder.Property(r => r.Name).IsRequired();

            // Configure the complex type RestaurantDetail
            builder.OwnsOne(r => r.Detail, rd =>
            {
                rd.Property(d => d.Address).IsRequired();
                rd.Property(d => d.Contact).IsRequired();
                rd.Property(d => d.Note).IsRequired();
            });

            // Configure the collection of RestaurantItems
            builder.HasMany(r => r.Items)
                   .WithOne(i => i.Restaurant)
                   .HasForeignKey(ConfigurationConstants.RestaurantIdColumnName); // a foreign key property in RestaurantItem

            builder.HasMany(r => r.AvailableCoupons)
                  .WithOne(i => i.Restaurant)
                  .HasForeignKey(ConfigurationConstants.RestaurantIdColumnName); // a foreign key property in RestaurantItem
        }
    }
}

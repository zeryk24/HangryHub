using HangryHub.MainService.Domain.ShoppingCartAggregate.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HangryHub.MainService.Domain.ShoppingCartAggregate.ValueObjects;

namespace HangryHub.MainService.Infrastructure.Configuration.ShoppingCartAggregateConfigs
{
    public class DeliveryDataConfiguration : IEntityTypeConfiguration<DeliveryData>
    {
        public void Configure(EntityTypeBuilder<DeliveryData> builder)
        {
            builder.ToTable("DeliveryData");

            builder.HasKey(dd => dd.Id);

            builder.Property(dd => dd.Id)
                   .HasConversion(id => id.Value, value => new DeliveryDataId(value))
                   .HasColumnName("DeliveryDataId");

            builder.Property(dd => dd.CustomerId)
                   .HasConversion(id => id.Value, value => new CustomerId(value))
                   .HasColumnName("CustomerId");

            builder.Property(dd => dd.DeliveryLocation).IsRequired();
            builder.Property(dd => dd.Contact).IsRequired();
            builder.Property(dd => dd.Note);
            builder.Property(dd => dd.IsActive).IsRequired();
        }
    }
}

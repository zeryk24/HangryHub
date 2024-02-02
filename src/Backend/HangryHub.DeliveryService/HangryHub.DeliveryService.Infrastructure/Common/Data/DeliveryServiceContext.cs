using HangryHub.DeliveryService.Domain.DeliveryAggregate.Entities;
using HangryHub.DeliveryService.Domain.DeliveryAggregate.Enums;
using HangryHub.DeliveryService.Domain.DeliveryAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace HangryHub.DeliveryService.Infrastructure.Common.Data
{
    public class DeliveryServiceContext : DbContext
    {

        #pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
        public DeliveryServiceContext(DbContextOptions options)
        #pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
                : base(options)
        {
        }


        public DbSet<Domain.DeliveryAggregate.Delivery> Deliveries { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DeliveryServiceContext).Assembly);

            var delivery = modelBuilder.Entity<Domain.DeliveryAggregate.Delivery>();
            delivery.HasKey(x => x.Id);

            var contact = delivery.OwnsOne(x => x.Customer);
            contact.OwnsOne(x => x.Contact);
            contact.OwnsOne(x => x.DeliveryLocation);
            contact.OwnsOne(x => x.Id);

            var freelencer = delivery.OwnsOne(x => x.Freelencer);
            freelencer.OwnsOne(x => x.Id);
            freelencer.OwnsOne(x => x.Contact);
        

            var order = delivery.OwnsOne(x => x.Order);
            order.OwnsOne(x => x.Id);

            var restaurant = delivery.OwnsOne(x => x.Restaurant);
            restaurant.OwnsOne(x => x.Location);
            restaurant.OwnsOne(x => x.Contact);
            restaurant.OwnsOne(x => x.Id);


         
        }
        
       


    }
}

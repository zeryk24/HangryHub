using HangryHub.MainService.Domain.RestaurantAggregate;
using HangryHub.MainService.Domain.RestaurantAggregate.Entities;
using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Infrastructure.Repository
{
    public class MainDBContext : DbContext
    {
        public MainDBContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<RestaurantItem> RestaurantItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MainDBContext).Assembly);

            // Configure Restaurant
            var restaurant = modelBuilder.Entity<Restaurant>();
            restaurant.HasKey(x => x.Id);
            restaurant.OwnsOne(x => x.Location);

            // Configure RestaurantItem
            var item = modelBuilder.Entity<RestaurantItem>();
            item.HasKey(x => x.Id);
            item.HasOne<Restaurant>() 
                .WithMany(r => r.Items);

            SeedDatabase(modelBuilder);
        }

        private void SeedDatabase(ModelBuilder modelBuilder)
        {
            var restaurantGUID = new Guid("575094cf-45c3-45f4-95c3-5a4089e6c425");
            var restaurantId = new RestaurantId(restaurantGUID);

            var restaurantLocationGUID = new Guid("c31fa625-50e5-4e64-99b6-8b0141672835");
            var restaurantLocationId = new RestaurantLocationId(restaurantGUID);

            var restaurantItemGUID1 = new Guid("70607720-f720-4b5b-b6ed-c3b3e11cb90e");
            var restaurantItemId1 = new RestaurantItemId(restaurantGUID);

            var restaurantItemGUID2 = new Guid("6a090d57-e8f2-4541-9d1a-88db8232f0f9");
            var restaurantItemId2 = new RestaurantItemId(restaurantGUID);

            var restaurantLocations = new List<RestaurantLocation>()
            {
                new()
                {
                    AddressLine1 = "Pepikova 11",
                    AddressLine2 = "Pepikov 69420",
                    Country = "Japan",
                }
            };

            var restaurantItems = new List<RestaurantItem>()
            {
                new(restaurantItemGUID1)
                {
                    Name = "Pizza 1",
                    Description = "Biggus pizzus 2mm",
                    Price = 10,
                },

                new(restaurantItemGUID2)
                {
                    Name = "Pizza 2",
                    Description = "Biggus pizzus 199cm",
                    Price = 10000,
                },
            };


            var restaurants = new List<Restaurant>()
            {
                new (restaurantId.Value)
                {
                    Name = "Pepikova Pizzoska",
                    Location = restaurantLocations[0],
                },
            };

            /*modelBuilder.Entity<Restaurant>()
                .HasData(restaurants);

            modelBuilder.Entity<RestaurantItem>()
                .HasData(restaurantItems);*/
        }
    }
}
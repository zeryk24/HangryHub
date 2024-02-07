using HangryHub.MainService.Domain.RestaurantAggregate;
using HangryHub.MainService.Domain.RestaurantAggregate.Entities;
using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using HangryHub.MainService.Domain.ShoppingCartAggregate;
using HangryHub.MainService.Domain.ShoppingCartAggregate.Entities;
using HangryHub.MainService.Infrastructure.Configuration;
using HangryHub.MainService.Infrastructure.Configuration.RestaurantAggregateConfigs;
using HangryHub.MainService.Infrastructure.Configuration.ShoppingCartAggregateConfigs;
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

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public DbSet<DeliveryData> DeliveryDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            base.OnModelCreating(modelBuilder);

            /*modelBuilder.ApplyConfigurationsFromAssembly(typeof(MainDBContext).Assembly);

            // Configure Restaurant
            var restaurant = modelBuilder.Entity<Restaurant>();
            restaurant.HasKey(x => x.Id);
            restaurant.OwnsOne(x => x.Location);

            // Configure RestaurantItem
            var item = modelBuilder.Entity<RestaurantItem>();
            item.HasKey(x => x.Restaurant);
            item.HasOne<Restaurant>() 
                .WithMany(r => r.Items);*/

            modelBuilder.ApplyConfiguration(new RestaurantConfiguration());
            modelBuilder.ApplyConfiguration(new RestaurantItemConfiguration());
            modelBuilder.ApplyConfiguration(new IngredientConfiguration());
            modelBuilder.ApplyConfiguration(new AdditionalIngredientConfiguration());
            modelBuilder.ApplyConfiguration(new CouponConfiguration());

            modelBuilder.ApplyConfiguration(new DeliveryDataConfiguration());
            modelBuilder.ApplyConfiguration(new ShoppingCartConfiguration());
            modelBuilder.ApplyConfiguration(new ShoppingCartItemConfiguration());
            modelBuilder.ApplyConfiguration(new SelectedAdditionalIngredientConfiguration());

            // Seeding is practically fucked ... It seems like EFCore is completely dumbfucked what to do with Owned entities.
            // In this case it fails like wildfire ...
            /*SeedDatabase(modelBuilder);*/
        }

        /*private void SeedDatabase(ModelBuilder modelBuilder)
        {
            var restaurantGUID = new Guid("575094cf-45c3-45f4-95c3-5a4089e6c425");
            var restaurantId = new RestaurantId(restaurantGUID);

            var restaurantItemGUID1 = new Guid("70607720-f720-4b5b-b6ed-c3b3e11cb90e");
            var restaurantItemId1 = new RestaurantItemId(restaurantItemGUID1);

            var restaurantItemGUID2 = new Guid("6a090d57-e8f2-4541-9d1a-88db8232f0f9");
            var restaurantItemId2 = new RestaurantItemId(restaurantItemGUID2);

            var restaurantLocations = new List<RestaurantDetail>()
            {
                new()
                {
                    Address = "Pepikova 11",
                    Contact = "Pepikov 69420",
                    Note = "Japan",
                }
            };


            var restaurants = new List<Restaurant>()
            {
                new (restaurantId)
                {
                    Name = "Pepikova Pizzoska",
                    Detail = restaurantLocations[0],
                },
            };

            modelBuilder.Entity<Restaurant>()
                .HasData(restaurants);

            var restaurantItems = new List<RestaurantItem>()
            {
                new(restaurantItemId1)
                {
                    RestaurantId = restaurantId,
                    Name = "Pizza 1",
                    Description = "Biggus pizzus 2mm",
                    Price = 10,
                },

                new(restaurantItemId2)
                {
                    RestaurantId = restaurantId,
                    Name = "Pizza 2",
                    Description = "Biggus pizzus 199cm",
                    Price = 10000,
                },
            };

            modelBuilder.Entity<RestaurantItem>()
                .HasData(restaurantItems);
        }*/
    }
}
using HangryHub.MainService.Domain.RestaurantAggregate;
using HangryHub.MainService.Domain.RestaurantAggregate.Entities;
using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using HangryHub.MainService.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Infrastructure
{
    public static class DatabaseSeeder
    {
        public static async Task SeedDatabaseAsync(MainDBContext dbContext)
        {
            var isSeeded = await dbContext.Restaurants.AnyAsync();

            if (isSeeded)
            {
                return;
            }

            var restaurantGUID = new Guid("575094cf-45c3-45f4-95c3-5a4089e6c425");
            var restaurantId = new RestaurantId(restaurantGUID);

            var restaurantItemGUID1 = new Guid("70607720-f720-4b5b-b6ed-c3b3e11cb90e");
            var restaurantItemId1 = new RestaurantItemId(restaurantItemGUID1);

            var restaurantItemGUID2 = new Guid("6a090d57-e8f2-4541-9d1a-88db8232f0f9");
            var restaurantItemId2 = new RestaurantItemId(restaurantItemGUID2);

            var generatedIngredients = IngredientGenerator();
            var additionalIngredients = AdditionalIngredientGenerator();

            var restaurantLocations = new List<RestaurantDetail>()
            {
                new()
                {
                    Address = "Pepikova 11",
                    Contact = "Pepikov 69420",
                    Note = "Japan",
                }
            };

            var additionalIngredientsAsAnonymObj = additionalIngredients
                .Select(a => new { Id = a.Value.id, Name = a.Key, Price = a.Value.price })
                .ToList();

            var ingredients = generatedIngredients
                .Select(a => new { Id = a.Value, Name = a.Key });

            var restaurantItems = new List<RestaurantItem>()
            {
                new(restaurantItemId1)
                {
                    RestaurantId = restaurantId,
                    Name = "Pizza 1",
                    Description = "Biggus pizzus 2mm",
                    Price = 230,
                    Ingredients = ingredients
                        .Select(a => new Ingredient(a.Id) { Name = a.Name, RestaurantItemId = restaurantItemId1 })
                        .Take(5)
                        .ToList(),
                    AdditionalIngredients = additionalIngredientsAsAnonymObj
                        .Select(a => new AdditionalIngredient(a.Id) { Name = a.Name, Price = a.Price, RestaurantItemId = restaurantItemId1 })
                        .Take(10)
                        .ToList(),
                },

                new(restaurantItemId2)
                {
                    RestaurantId = restaurantId,
                    Name = "Pizza 2",
                    Description = "Biggus pizzus 199cm",
                    Price = 10000,
                    Ingredients = ingredients
                        .Select(a => new Ingredient(a.Id) { Name = a.Name, RestaurantItemId = restaurantItemId2 })
                        .Skip(5)
                        .ToList(),
                    AdditionalIngredients = additionalIngredientsAsAnonymObj
                        .Select(a => new AdditionalIngredient(a.Id) { Name = a.Name, Price = a.Price, RestaurantItemId = restaurantItemId1 })
                        .Skip(10)
                        .ToList(),
                },
            };

            var coupons = new List<Coupon>()
            {
                new (new (new ("00000000-0000-0000-0000-000000000030")))
                {
                    RestaurantId = restaurantId,
                    ExpirationDateTime = new DateTime(2024, 03, 01, 10, 0, 0),
                    Name = "100 CZK off",
                    Price = 100,
                },

                new (new (new ("00000000-0000-0000-0000-000000000031")))
                {
                    RestaurantId = restaurantId,
                    ExpirationDateTime = new DateTime(2024, 02, 15, 10, 0, 0),
                    Name = "200 CZK off",
                    Price = 200,
                },

                new (new (new ("00000000-0000-0000-0000-000000000032")))
                {
                    RestaurantId = restaurantId,
                    ExpirationDateTime = new DateTime(2024, 03, 22, 10, 0, 0),
                    Name = "300 CZK off",
                    Price = 300,
                },
            };

            var restaurants = new List<Restaurant>()
            {
                new (restaurantId)
                {
                    Name = "Pepikova Pizzoska",
                    Detail = restaurantLocations[0],
                    Items = restaurantItems,
                    AvailableCoupons = coupons,
                },
            };

            dbContext.AddRange(restaurants);
            await dbContext.SaveChangesAsync();

            var result = await dbContext.Restaurants
                .Include(a => a.Items)
                .ThenInclude(item => item.Ingredients)
                .Include(a => a.Items)
                .ThenInclude(item => item.AdditionalIngredients)
                .Include(a => a.AvailableCoupons)
                .ToListAsync();

            foreach (var item in result)
            {
                var a = item.Items.Select(a => a.Ingredients.Select(a => a.Name)).ToList();
                var b = item.Items.Select(a => a.AdditionalIngredients.Select(a => new { a.Name, a.Price })).ToList();
            }

            var debugBreak = 10;
        }

        private static Dictionary<string, IngredientId> IngredientGenerator()
        {
            return new Dictionary<string, IngredientId>()
            {
                { "Ham", new IngredientId(Guid.NewGuid()) },
                { "Tomato", new IngredientId(Guid.NewGuid()) },
                { "Cheese", new IngredientId(Guid.NewGuid()) },
                { "Onion", new IngredientId(Guid.NewGuid()) },
                { "Chicken", new IngredientId(Guid.NewGuid()) },
                { "Pasta", new IngredientId(Guid.NewGuid()) },
                { "Beef", new IngredientId(Guid.NewGuid()) },
                { "Garlic", new IngredientId(Guid.NewGuid()) },
                { "Lettuce", new IngredientId(Guid.NewGuid()) },
                { "Mushroom", new IngredientId(Guid.NewGuid()) },
                { "Shrimp", new IngredientId(Guid.NewGuid()) },
                { "Bell Pepper", new IngredientId(Guid.NewGuid()) },
                { "Bacon", new IngredientId(Guid.NewGuid()) },
                { "Egg", new IngredientId(Guid.NewGuid()) },
                { "Avocado", new IngredientId(Guid.NewGuid()) },
                { "Salmon", new IngredientId(Guid.NewGuid()) },
            };
        }

        private static Dictionary<string, (AdditionalIngredientId id, decimal price)> AdditionalIngredientGenerator()
        {
            return new Dictionary<string, (AdditionalIngredientId id, decimal price)>()
            {
                { "Ham", (new (Guid.NewGuid()), 20) },
                { "Tomato", (new (new Guid("00000000-0000-0000-0000-000000000001")), 30) },
                { "Cheese", (new (new Guid("00000000-0000-0000-0000-000000000002")), 40) },
                { "Onion", (new (new Guid("00000000-0000-0000-0000-000000000003")), 50) },
                { "Chicken", (new (new Guid("00000000-0000-0000-0000-000000000004")), 60) },
                { "Pasta", (new (new Guid("00000000-0000-0000-0000-000000000005")), 70) },
                { "Beef", (new (new Guid("00000000-0000-0000-0000-000000000006")), 80) },
                { "Garlic", (new (new Guid("00000000-0000-0000-0000-000000000007")), 90) },
                { "Lettuce", (new (new Guid("00000000-0000-0000-0000-000000000008")), 20) },
                { "Mushroom", (new (new Guid("00000000-0000-0000-0000-000000000009")), 30) },
                { "Shrimp", (new (new Guid("00000000-0000-0000-0000-000000000010")), 40) },
                { "Bell Pepper", (new (new Guid("00000000-0000-0000-0000-000000000011")), 50) },
                { "Bacon", (new (new Guid("00000000-0000-0000-0000-000000000012")), 60) },
                { "Egg", (new (new Guid("00000000-0000-0000-0000-000000000013")), 70) },
                { "Avocado", (new (new Guid("00000000-0000-0000-0000-000000000014")), 80) },
                { "Salmon", (new (new Guid("00000000-0000-0000-0000-000000000015")), 90) },
                { "Tofu", (new (new Guid("00000000-0000-0000-0000-000000000016")), 20) },
                { "Rice", (new (new Guid("00000000-0000-0000-0000-000000000017")), 30) },
                { "Soy Sauce", (new (new Guid("00000000-0000-0000-0000-000000000018")), 40) },
                { "Cilantro", (new (new Guid("00000000-0000-0000-0000-000000000019")), 50) },
                { "Pineapple", (new (new Guid("00000000-0000-0000-0000-000000000020")), 60) },
                { "Corn", (new (new Guid("00000000-0000-0000-0000-000000000021")), 70) },
                { "Spinach", (new (new Guid("00000000-0000-0000-0000-000000000022")), 80) },
                { "Zucchini", (new (new Guid("00000000-0000-0000-0000-000000000023")), 90) },
                { "Cucumber", (new (new Guid("00000000-0000-0000-0000-000000000024")), 20) },
                { "Carrot", (new (new Guid("00000000-0000-0000-0000-000000000025")), 30) },
                { "Sausage", (new (new Guid("00000000-0000-0000-0000-000000000026")), 40) },
                { "RandomKeyViolation", (new (new Guid("00000000-0000-0000-0000-000000000027")), 50) },
                { "Cabbage", (new (new Guid("00000000-0000-0000-0000-000000000028")), 60) },
                { "Lemon", (new (new Guid("00000000-0000-0000-0000-000000000029")), 70) },
                { "Honey", (new (new Guid("00000000-0000-0000-0000-000000000030")), 80) }
            };
        }
    }
}

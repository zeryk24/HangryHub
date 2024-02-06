using HangryHub.RestaurantService.Domain.RestaurantAggregate.Entities.IngredientEntity.ValueObjects;
using HangryHub.RestaurantService.Domain.RestaurantAggregate.Entities.IngredientEntity;
using HangryHub.RestaurantService.Domain.RestaurantAggregate.Entities.MenuItemEntity.ValueObjects;
using HangryHub.RestaurantService.Domain.RestaurantAggregate.Entities.MenuItemEntity;
using HangryHub.RestaurantService.Domain.RestaurantAggregate;
using HangryHub.RestaurantService.Application.RestaurantRequests.Models;

namespace HangryHub.RestaurantService.Application.RestaurantRequests;

internal static class RestaurantMapper
{
    internal static List<MenuItem> CreateMenuItems(IEnumerable<MenuItemModel> menuItemModels)
    {
        List<MenuItem> menuItems = new();

        foreach (var menuItemModel in menuItemModels)
        {
            var id = MenuItemId.CreateUnique();
            var name = MenuItemName.Create(menuItemModel.Name);
            var description = MenuItemDescription.Create(menuItemModel.Description);
            var price = MenuItemPrice.Create(menuItemModel.PriceCzk);
            var ingredients = CreateIngredients(menuItemModel.ingredients);

            var newMenuItem = MenuItem.Create(id, name, description, price, ingredients);

            menuItems.Add(newMenuItem);
        }

        return menuItems;
    }

    internal static List<Ingredient> CreateIngredients(IEnumerable<IngredientModel> ingredientModels)
    {
        List<Ingredient> ingredients = new();

        foreach (var ingredientModel in ingredientModels)
        {
            var id = IngredientId.CreateUnique();
            var name = IngredientName.Create(ingredientModel.Name);
            var weight = IngredientWeight.Create(ingredientModel.Grams);

            var newIngredient = Ingredient.Create(id, name, weight);

            ingredients.Add(newIngredient);
        }

        return ingredients;
    }

    internal static RestaurantIdModel MapRestaurantToModel(Restaurant restaurant)
    {
        return new(
            restaurant.Id.Value,
            restaurant.Name.Value,
            restaurant.Description.Value,
            restaurant.MenuItems.Select(MapMenuItemToModel)
       );
    }

    internal static MenuItemIdModel MapMenuItemToModel(MenuItem menuItem)
    {
        return new(
            menuItem.Id.Value,
            menuItem.Name.Value,
            menuItem.Description.Value,
            menuItem.Price.Czk,
            menuItem.Ingredients.Select(MapIngredientToModel)
       );
    }

    internal static IngredientModel MapIngredientToModel(Ingredient ingredient)
    {
        return new(
            ingredient.Name.Value,
            ingredient.Weight.Grams
       );
    }
}

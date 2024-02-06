namespace HangryHub.RestaurantService.Application.RestaurantRequests.Models;

public record MenuItemModel(string Name, string Description, decimal PriceCzk, IEnumerable<IngredientModel> ingredients);

public record MenuItemIdModel(Guid Id, string Name, string Description, decimal PriceCzk, IEnumerable<IngredientModel> ingredients) : MenuItemModel(Name, Description, PriceCzk, ingredients);

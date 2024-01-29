namespace HangryHub.RestaurantService.Application.RestaurantRequests.Models;

public record RestaurantModel(string Name, string Description, IEnumerable<MenuItemModel> MenuItems);

public record RestaurantIdModel(Guid Id, string Name, string Description, IEnumerable<MenuItemModel> MenuItems) : RestaurantModel(Name, Description, MenuItems);

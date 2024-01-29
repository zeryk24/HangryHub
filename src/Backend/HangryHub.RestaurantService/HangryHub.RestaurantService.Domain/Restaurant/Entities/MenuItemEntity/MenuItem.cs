using HangryHub.RestaurantService.Domain.Common.Models;
using HangryHub.RestaurantService.Domain.Restaurant.Entities.IngredientEntity;
using HangryHub.RestaurantService.Domain.Restaurant.Entities.MenuItemEntity.ValueObjects;
using HangryHub.RestaurantService.Domain.Restaurant.ValueObjects;
using RestaurantDescription = HangryHub.RestaurantService.Domain.Restaurant.ValueObjects.RestaurantDescription;

namespace HangryHub.RestaurantService.Domain.Restaurant.Entities.MenuItemEntity;

public class MenuItem : Entity<MenuItemId>
{
    public MenuItemName Name { get; private set; }
    public MenuItemDescription Description { get; private set; }
    public MenuItemPrice Price { get; private set; }

    private readonly List<Ingredient> _ingredients = [];
    public IReadOnlyList<Ingredient> Ingredients => _ingredients.AsReadOnly();

    private MenuItem() {}

    private MenuItem(MenuItemId id, MenuItemName name, MenuItemDescription description, MenuItemPrice price) : base(id)
    {
        Price = price;
        Description = description;
        Name = name;
    }

    public static MenuItem Create(MenuItemId id, MenuItemName name, MenuItemDescription description, MenuItemPrice price) => new MenuItem(id, name, description, price);
}

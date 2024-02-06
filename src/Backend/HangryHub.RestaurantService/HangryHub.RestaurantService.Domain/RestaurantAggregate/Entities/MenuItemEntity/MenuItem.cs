using HangryHub.RestaurantService.Domain.Common.Models;
using HangryHub.RestaurantService.Domain.RestaurantAggregate.Entities.IngredientEntity;
using HangryHub.RestaurantService.Domain.RestaurantAggregate.Entities.MenuItemEntity.ValueObjects;

namespace HangryHub.RestaurantService.Domain.RestaurantAggregate.Entities.MenuItemEntity;

public class MenuItem : Entity<MenuItemId>
{
    public MenuItemName Name { get; private set; }
    public MenuItemDescription Description { get; private set; }
    public MenuItemPrice Price { get; private set; }

    private readonly List<Ingredient> _ingredients = [];
    public IReadOnlyList<Ingredient> Ingredients => _ingredients.AsReadOnly();

    private MenuItem() {}

    private MenuItem(MenuItemId id, MenuItemName name, MenuItemDescription description, MenuItemPrice price, List<Ingredient> ingredients) : base(id)
    {
        Price = price;
        Description = description;
        Name = name;
        _ingredients = ingredients;
    }

    public static MenuItem Create(MenuItemId id, MenuItemName name, MenuItemDescription description, MenuItemPrice price, List<Ingredient> ingredients) => 
        new MenuItem(id, name, description, price, ingredients);
}

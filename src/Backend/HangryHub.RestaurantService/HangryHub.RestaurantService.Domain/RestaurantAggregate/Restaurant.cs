using HangryHub.RestaurantService.Domain.Common.Models;
using HangryHub.RestaurantService.Domain.RestaurantAggregate.Entities.MenuItemEntity;
using HangryHub.RestaurantService.Domain.RestaurantAggregate.ValueObjects;

namespace HangryHub.RestaurantService.Domain.RestaurantAggregate;

public sealed class Restaurant : AggregateRoot<RestaurantId>
{
    public RestaurantName Name { get; private set; }

    public RestaurantDescription Description { get; private set; }

    private readonly List<MenuItem> _menuItems = [];
    public IReadOnlyList<MenuItem> MenuItems => _menuItems.AsReadOnly();

    private Restaurant() {}

    private Restaurant(RestaurantId id, RestaurantName name, RestaurantDescription description, List<MenuItem> menuItems) : base(id)
    {
        Name = name;
        Description = description;
        _menuItems = menuItems;
    }

    public static Restaurant Create(RestaurantId id, RestaurantName name, RestaurantDescription description, List<MenuItem> menuItems) => new Restaurant(id, name, description, menuItems);
}

using HangryHub.RestaurantService.Domain.Common.Models;

namespace HangryHub.RestaurantService.Domain.Restaurant.Entities.MenuItemEntity.ValueObjects;

public class MenuItemName : ValueObject
{
    public string Value { get; private set; }

    private MenuItemName() { }

    private MenuItemName(string value)
    {
        Value = value;
    }

    public static MenuItemName Create(string value) => new MenuItemName(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}

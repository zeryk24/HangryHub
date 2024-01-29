using HangryHub.RestaurantService.Domain.Common.Models;

namespace HangryHub.RestaurantService.Domain.RestaurantAggregate.Entities.MenuItemEntity.ValueObjects;

public class MenuItemDescription : ValueObject
{
    public string Value { get; private set; }

    private MenuItemDescription() { }

    private MenuItemDescription(string value)
    {
        Value = value;
    }

    public static MenuItemDescription Create(string value) => new MenuItemDescription(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}

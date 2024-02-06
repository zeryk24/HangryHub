using HangryHub.RestaurantService.Domain.Common.Models;

namespace HangryHub.RestaurantService.Domain.RestaurantAggregate.Entities.MenuItemEntity.ValueObjects;

public class MenuItemId : ValueObject
{
    public Guid Value { get; private set; }

    private MenuItemId(Guid value)
    {
        Value = value;
    }

    public static MenuItemId CreateUnique() => new MenuItemId(Guid.NewGuid());
    public static MenuItemId Create(Guid value) => new MenuItemId(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}

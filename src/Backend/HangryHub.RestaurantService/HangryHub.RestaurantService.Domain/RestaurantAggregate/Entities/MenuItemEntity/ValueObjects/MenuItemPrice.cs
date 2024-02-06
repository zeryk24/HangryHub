using HangryHub.RestaurantService.Domain.Common.Models;

namespace HangryHub.RestaurantService.Domain.RestaurantAggregate.Entities.MenuItemEntity.ValueObjects;

public class MenuItemPrice : ValueObject
{
    public decimal Czk { get; private set; }

    private MenuItemPrice() { }

    private MenuItemPrice(decimal czk)
    {
        Czk = czk;
    }

    public static MenuItemPrice Create(decimal czk) => new MenuItemPrice(czk);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Czk;
    }
}

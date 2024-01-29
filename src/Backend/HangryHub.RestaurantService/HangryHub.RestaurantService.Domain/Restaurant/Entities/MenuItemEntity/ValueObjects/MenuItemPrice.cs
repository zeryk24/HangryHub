using HangryHub.RestaurantService.Domain.Common.Models;

namespace HangryHub.RestaurantService.Domain.Restaurant.Entities.MenuItemEntity.ValueObjects;

public class MenuItemPrice : ValueObject
{
    public decimal Czk { get; private set; }

    private MenuItemPrice() { }

    private MenuItemPrice(decimal value)
    {
        Czk = value;
    }

    public static MenuItemPrice Create(decimal value) => new MenuItemPrice(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Czk;
    }
}

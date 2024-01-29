using HangryHub.RestaurantService.Domain.Common.Models;

namespace HangryHub.RestaurantService.Domain.Restaurant.Entities.IngredientEntity.ValueObjects;

public class IngredientName : ValueObject
{
    public string Value { get; private set; }

    private IngredientName() { }

    private IngredientName(string value)
    {
        Value = value;
    }

    public static IngredientName Create(string value) => new IngredientName(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}

using HangryHub.RestaurantService.Domain.Common.Models;

namespace HangryHub.RestaurantService.Domain.Restaurant.Entities.IngredientEntity.ValueObjects;

public class IngredientId : ValueObject
{
    public Guid Value { get; private set; }

    private IngredientId() { }
    private IngredientId(Guid value)
    {
        Value = value;
    }

    public static IngredientId CreateUnique() => new IngredientId(Guid.NewGuid());
    public static IngredientId Create(Guid value) => new IngredientId(value);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

}

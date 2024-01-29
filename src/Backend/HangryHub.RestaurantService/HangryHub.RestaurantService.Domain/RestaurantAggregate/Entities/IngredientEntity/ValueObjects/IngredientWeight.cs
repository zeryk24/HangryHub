using HangryHub.RestaurantService.Domain.Common.Models;

namespace HangryHub.RestaurantService.Domain.RestaurantAggregate.Entities.IngredientEntity.ValueObjects;

public class IngredientWeight : ValueObject
{
    public float Grams { get; private set; }

    private IngredientWeight() { }

    private IngredientWeight(float grams)
    {
        Grams = grams;
    }

    public static IngredientWeight Create(float grams) => new IngredientWeight(grams);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Grams;
    }
}

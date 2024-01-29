using HangryHub.RestaurantService.Domain.Common.Models;
using HangryHub.RestaurantService.Domain.Restaurant.Entities.IngredientEntity.ValueObjects;

namespace HangryHub.RestaurantService.Domain.Restaurant.Entities.IngredientEntity;

public class Ingredient : Entity<IngredientId>
{
    public IngredientName Name { get; private set; }

    public IngredientWeight Weight { get; private set; }

    private Ingredient() {}

    private Ingredient(IngredientId id, IngredientName name, IngredientWeight weight) : base(id)
    {
        Name = name;
        Weight = weight;
    }

    public static Ingredient Create(IngredientId id, IngredientName name, IngredientWeight weight) => new Ingredient(id, name, weight);
}

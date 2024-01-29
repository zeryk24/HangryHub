using HangryHub.RestaurantService.Domain.Common.Models;

namespace HangryHub.RestaurantService.Domain.Restaurant.ValueObjects;

public class RestaurantName : ValueObject
{
    public string Value { get; private set; }

    private RestaurantName() { }

    private RestaurantName(string value)
    {
        Value = value;
    }

    public static RestaurantName Create(string value) => new RestaurantName(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}

using HangryHub.RestaurantService.Domain.Common.Models;

namespace HangryHub.RestaurantService.Domain.RestaurantAggregate.ValueObjects;

public class RestaurantDescription : ValueObject
{
    public string Value { get; private set; }

    private RestaurantDescription() { }

    private RestaurantDescription(string value)
    {
        Value = value;
    }

    public static RestaurantDescription Create(string value) => new RestaurantDescription(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}

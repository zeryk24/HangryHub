using HangryHub.RestaurantService.Domain.Common.Models;

namespace HangryHub.RestaurantService.Domain.Restaurant.ValueObjects;

public class RestaurantId : ValueObject
{
    public Guid Value { get; private set; }

    private RestaurantId(Guid value)
    {
        Value = value;
    }

    public static RestaurantId CreateUnique() => new RestaurantId(Guid.NewGuid());
    public static RestaurantId Create(Guid value) => new RestaurantId(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}

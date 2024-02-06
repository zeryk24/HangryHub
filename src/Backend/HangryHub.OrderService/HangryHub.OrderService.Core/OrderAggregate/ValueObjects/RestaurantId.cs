using HangryHub.OrderService.Core.Common;

namespace HangryHub.OrderService.Core.OrderAggregate.ValueObjects
{
    public class RestaurantId : ValueObject
    {
        public Guid Id { get; private set; }

        public RestaurantId(Guid id)
        {
            Id = id;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}

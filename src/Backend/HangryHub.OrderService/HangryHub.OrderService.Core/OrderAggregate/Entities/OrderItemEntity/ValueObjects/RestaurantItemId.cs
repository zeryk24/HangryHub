using HangryHub.OrderService.Core.Common;

namespace HangryHub.OrderService.Core.OrderAggregate.Entities.OrderItemEntity.ValueObjects
{
    public class RestaurantItemId : ValueObject
    {
        public Guid ItemId { get; private set; }

        public RestaurantItemId(Guid itemId)
        {
            ItemId = itemId;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return ItemId;
        }
    }
}

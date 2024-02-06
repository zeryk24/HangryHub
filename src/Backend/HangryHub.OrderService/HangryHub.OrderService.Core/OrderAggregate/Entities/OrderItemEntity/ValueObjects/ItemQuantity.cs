using HangryHub.OrderService.Core.Common;

namespace HangryHub.OrderService.Core.OrderAggregate.Entities.OrderItemEntity.ValueObjects
{
    public class ItemQuantity : ValueObject
    {
        public int Quantity { get; private set; }

        public ItemQuantity(int quantity)
        {
            Quantity = quantity;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Quantity;
        }
    }
}

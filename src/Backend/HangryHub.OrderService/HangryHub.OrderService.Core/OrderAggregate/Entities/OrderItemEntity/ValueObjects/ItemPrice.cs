using HangryHub.OrderService.Core.Common;

namespace HangryHub.OrderService.Core.OrderAggregate.Entities.OrderItemEntity.ValueObjects
{
    public class ItemPrice : ValueObject
    {
        public double Price { get; private set; }

        public ItemPrice(double price)
        {
            Price = price;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Price;
        }
    }
}

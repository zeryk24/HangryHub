using HangryHub.OrderService.Core.Common;

namespace HangryHub.OrderService.Core.OrderAggregate.Entities.OrderItemEntity.ValueObjects
{
    public class ItemName : ValueObject
    {
        public string Name { get; private set; }

        public ItemName(string name)
        {
            Name = name;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}

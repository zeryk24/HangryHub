using HangryHub.OrderService.Core.Common;

namespace HangryHub.OrderService.Core.OrderAggregate.Entities.CouponEntity.ValueObjects
{
    public class CouponName : ValueObject
    {
        public string Name { get; private set; }

        public CouponName(string name)
        {
            Name = name;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}

using HangryHub.OrderService.Core.Common;

namespace HangryHub.OrderService.Core.OrderAggregate.Entities.CouponEntity.ValueObjects
{
    public class CouponPrice : ValueObject
    {
        public double EuroPrice { get; private set; }

        public CouponPrice(int euroPrice)
        {
            EuroPrice = euroPrice;
        }

        private CouponPrice()
        {
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return EuroPrice;
        }
    }
}

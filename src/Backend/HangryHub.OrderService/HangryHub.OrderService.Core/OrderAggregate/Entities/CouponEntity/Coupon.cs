using HangryHub.OrderService.Core.Common;
using HangryHub.OrderService.Core.OrderAggregate.Entities.CouponEntity.ValueObjects;

namespace HangryHub.OrderService.Core.OrderAggregate.Entities.CouponEntity
{
    public class Coupon : Entity<Guid>
    {
        public CouponName Name { get; private set; }
        public CouponPrice Price { get; set; }

        public Coupon(CouponName name, CouponPrice price)
        {
            Name = name;
            Price = price;
        }

        private Coupon() { }
    }
}

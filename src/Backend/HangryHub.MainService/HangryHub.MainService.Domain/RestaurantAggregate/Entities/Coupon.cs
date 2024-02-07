using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Domain.RestaurantAggregate.Entities
{
    public class Coupon : Entity<CouponId>
    {
        public required RestaurantId RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required DateTime ExpirationDateTime { get; set; }

        private Coupon() { }

        public Coupon(CouponId id) : base(id)
        {
        }
    }
}

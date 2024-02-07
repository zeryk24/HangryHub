using HangryHub.MainService.Domain.RestaurantAggregate.Entities;
using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;

namespace HangryHub.MainService.Domain.RestaurantAggregate
{
    public class Restaurant : AggregateRoot<RestaurantId>
    {
        private Restaurant() { }

        public Restaurant(RestaurantId id) : base(id)
        {
        }

        public required string Name { get; set; }

        public required RestaurantDetail Detail { get; set; }

        public virtual IEnumerable<RestaurantItem> Items { get; set; } = new List<RestaurantItem>();

        public virtual IEnumerable<Coupon> AvailableCoupons { get; set; } = new List<Coupon>();
    }
}

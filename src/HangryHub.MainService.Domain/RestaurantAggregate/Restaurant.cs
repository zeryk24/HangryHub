using HangryHub.MainService.Domain.RestaurantAggregate.Entities;
using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;

namespace HangryHub.MainService.Domain.RestaurantAggregate
{
    public class Restaurant : AggregateRoot<Guid>
    {
        public Restaurant(Guid id) : base(id)
        {
        }

        public required string Name { get; set; }

        public required RestaurantLocation Location { get; set; }

        public IEnumerable<RestaurantItem> Items { get; set; } = new List<RestaurantItem>();
    }
}

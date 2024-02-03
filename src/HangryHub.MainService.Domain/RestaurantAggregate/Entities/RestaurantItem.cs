using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;

namespace HangryHub.MainService.Domain.RestaurantAggregate.Entities
{
    public class RestaurantItem : Entity<Guid>
    {
        public Restaurant? Restaurant { get; }

        public RestaurantItem(Guid id) : base(id)
        {
        }

        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
    }
}

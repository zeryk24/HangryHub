using HangryHub.DeliveryService.Domain.Common;
using HangryHub.DeliveryService.Domain.DeliveryAggregate.ValueObjects;

namespace HangryHub.DeliveryService.Domain.DeliveryAggregate.Entities
{
    public class RestaurantDeliveryInfo : Entity
    {
        public RestaurantId Id { get; private set; }
        public string Name { get; private set; }
        public RestaurantContact Contact { get; private set; }
        public RestaurantLocation Location { get; private set; }

        public RestaurantDeliveryInfo(RestaurantId id, RestaurantContact contact, RestaurantLocation location, string name)
        {
            Id = id;
            Contact = contact;
            Location = location;
            Name = name;
        }



#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private RestaurantDeliveryInfo()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }
    }
}

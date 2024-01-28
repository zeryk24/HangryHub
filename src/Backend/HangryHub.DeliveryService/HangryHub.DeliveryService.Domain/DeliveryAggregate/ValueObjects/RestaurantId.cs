using HangryHub.DeliveryService.Domain.Common;

namespace HangryHub.DeliveryService.Domain.DeliveryAggregate.ValueObjects
{
    public class RestaurantId : IdValueObject<RestaurantId>
    {
        public RestaurantId(Guid id) : base(id)
        {
        }
    }
}

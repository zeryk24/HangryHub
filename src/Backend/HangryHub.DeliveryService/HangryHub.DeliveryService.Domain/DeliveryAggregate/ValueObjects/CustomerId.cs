using HangryHub.DeliveryService.Domain.Common;

namespace HangryHub.DeliveryService.Domain.DeliveryAggregate.ValueObjects
{
    public class CustomerId : IdValueObject<CustomerId>
    {
        public CustomerId(Guid id) : base(id)
        {
        }
    }
}

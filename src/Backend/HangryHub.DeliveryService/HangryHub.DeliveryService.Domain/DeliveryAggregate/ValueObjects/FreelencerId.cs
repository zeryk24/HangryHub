using HangryHub.DeliveryService.Domain.Common;

namespace HangryHub.DeliveryService.Domain.DeliveryAggregate.ValueObjects
{
    public class FreelencerId : IdValueObject<FreelencerId>
    {
        public FreelencerId(Guid id) : base(id)
        {
        }
    }
}

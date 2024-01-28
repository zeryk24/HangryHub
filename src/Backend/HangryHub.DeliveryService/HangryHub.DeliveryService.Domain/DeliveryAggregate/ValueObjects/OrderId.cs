using HangryHub.DeliveryService.Domain.Common;

namespace HangryHub.DeliveryService.Domain.DeliveryAggregate.ValueObjects
{
    public class OrderId : IdValueObject<OrderId>
    {
        public OrderId(Guid id) : base(id)
        {
        }
    }
}

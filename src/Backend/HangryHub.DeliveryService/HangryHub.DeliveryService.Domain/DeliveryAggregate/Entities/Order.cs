using HangryHub.DeliveryService.Domain.Common;
using HangryHub.DeliveryService.Domain.DeliveryAggregate.ValueObjects;

namespace HangryHub.DeliveryService.Domain.DeliveryAggregate.Entities
{
    public class Order(OrderId id) : Entity
    {
        public OrderId Id { get; private set; } = id;
    }
}

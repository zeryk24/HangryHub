using HangryHub.DeliveryService.Domain.DeliveryAggregate.ValueObjects;

namespace HangryHub.DeliveryService.Application.Delivery.Queries.ListAvaiable
{
    public record ListAvaiableQueryResultItem
    {
        public required Guid DeliveryId { get; init; }
        public required RestaurantLocation Restaurant { get; init; }
        public required CustomerDeliveryLocation CustomerDeliveryLocation { get; init; }
    }
}

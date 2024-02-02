using MediatR;

namespace HangryHub.DeliveryService.Application.Delivery.Select
{

    public record PickupDeliveryCommand(Guid DeliveryId) : IRequest<bool>
    {

    }
}

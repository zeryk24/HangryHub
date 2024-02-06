using MediatR;

namespace HangryHub.DeliveryService.Application.Delivery.Commands.Pickup
{

    public record PickupDeliveryCommand(Guid DeliveryId) : IRequest<bool>
    {

    }
}

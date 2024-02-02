using MediatR;

namespace HangryHub.DeliveryService.Application.Delivery.Select
{

    public record CompleteDeliveryCommand(Guid DeliveryId) : IRequest<bool>
    {

    }
}

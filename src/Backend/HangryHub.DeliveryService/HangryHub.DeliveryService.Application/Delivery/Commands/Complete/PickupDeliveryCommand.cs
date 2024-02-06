using MediatR;

namespace HangryHub.DeliveryService.Application.Delivery.Commands.Complete
{

    public record CompleteDeliveryCommand(Guid DeliveryId) : IRequest<bool>
    {

    }
}

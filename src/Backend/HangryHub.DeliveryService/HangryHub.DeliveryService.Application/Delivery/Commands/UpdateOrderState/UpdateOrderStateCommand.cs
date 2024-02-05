using HangryHub.OrderService.Contracts.Messages;
using MediatR;

namespace HangryHub.DeliveryService.Application.Delivery.Commands.Complete
{

    public record UpdateOrderStateCommand(Guid OrderId, OrderStatus Status) : IRequest<bool>
    {

    }
}

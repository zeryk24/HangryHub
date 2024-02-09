using HangryHub.MainService.Contracts.Messages;
using MediatR;

namespace HangryHub.DeliveryService.Application.Delivery.Commands.Complete
{

    public record CreateFromOrderCommand(OrderMessage Message) : IRequest
    {

    }
}

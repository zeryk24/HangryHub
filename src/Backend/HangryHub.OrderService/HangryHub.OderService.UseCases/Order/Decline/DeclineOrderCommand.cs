using ErrorOr;
using MediatR;

namespace HangryHub.OderService.UseCases.Order.Decline
{
    public record DeclineOrderCommand(Guid Id) : IRequest<ErrorOr<OrderDTO>> { }
}

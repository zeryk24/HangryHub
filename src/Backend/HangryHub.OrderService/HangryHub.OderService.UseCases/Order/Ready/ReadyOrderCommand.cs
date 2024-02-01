using ErrorOr;
using MediatR;

namespace HangryHub.OderService.UseCases.Order.Ready
{
    public record ReadyOrderCommand(Guid Id) : IRequest<ErrorOr<OrderDTO>> { }
}

using ErrorOr;
using MediatR;

namespace HangryHub.OderService.UseCases.Order.CheckStatus
{
    public record CheckStatusOrderCommand(Guid Id) : IRequest<ErrorOr<OrderStatusDTO>> { }
}

using ErrorOr;
using MediatR;

namespace HangryHub.OderService.UseCases.Order.Accept
{
    public record AcceptOrderCommand(Guid Id) : IRequest<ErrorOr<OrderDTO>> { }
}

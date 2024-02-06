using ErrorOr;
using HangryHub.OderService.UseCases.Order.DTOs;
using MediatR;

namespace HangryHub.OderService.UseCases.Order.Accept
{
    public record AcceptOrderCommand(Guid Id) : IRequest<ErrorOr<OrderDTO>> { }
}

using HangryHub.OderService.UseCases.Order.DTOs;
using MediatR;

namespace HangryHub.OderService.UseCases.Order.Create
{
    public record CreateOrderCommand(OrderDTO orderDTO) : IRequest<OrderDTO> { }
}

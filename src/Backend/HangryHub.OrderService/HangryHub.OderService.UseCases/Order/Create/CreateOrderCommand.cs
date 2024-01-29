using MediatR;

namespace HangryHub.OderService.UseCases.Order.Create
{
    public record CreateOrderCommand(double EuroPrice) : IRequest<OrderDTO> { }
}

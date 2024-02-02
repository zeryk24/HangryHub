using MediatR;

namespace HangryHub.OderService.UseCases.Order.GetById
{
    public record GetOrderByIdQuery(Guid Id) : IRequest<OrderDTO> { }
}

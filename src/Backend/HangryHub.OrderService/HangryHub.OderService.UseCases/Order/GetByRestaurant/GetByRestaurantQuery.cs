using ErrorOr;
using HangryHub.OderService.UseCases.Order.DTOs;
using MediatR;

namespace HangryHub.OderService.UseCases.Order.GetByRestaurant
{
    public record GetByRestaurantQuery(Guid Id) : IRequest<ErrorOr<List<OrderDTO>>> { }
}

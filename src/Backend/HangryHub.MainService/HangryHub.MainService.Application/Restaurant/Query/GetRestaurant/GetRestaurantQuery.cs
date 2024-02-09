using ErrorOr;
using HangryHub.MainService.Application.DTOs.RestaurantAggregate;
using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using MediatR;

namespace HangryHub.MainService.Application.Restaurant.Query.GetRestaurant
{
    public class GetRestaurantQuery : IRequest<ErrorOr<RestaurantDto>>
    {
        public required Guid RestaurantId { get; set; }
    }
}

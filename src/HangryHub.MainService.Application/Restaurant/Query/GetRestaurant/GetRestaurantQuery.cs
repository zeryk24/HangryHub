using ErrorOr;
using HangryHub.MainService.Application.Restaurant.DTOs;
using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using MediatR;

namespace HangryHub.MainService.Application.Restaurant.Query.GetRestaurant
{
    public class GetRestaurantQuery : IRequest<ErrorOr<RestaurantDto>>
    {
        public required RestaurantId RestaurantId { get; set; }
    }
}

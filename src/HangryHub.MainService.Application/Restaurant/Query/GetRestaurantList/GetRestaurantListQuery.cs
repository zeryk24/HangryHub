using ErrorOr;
using HangryHub.MainService.Application.Restaurant.DTOs;
using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using MediatR;

namespace HangryHub.MainService.Application.Restaurant.Query.GetRestaurantList
{
    public class GetRestaurantListQuery : IRequest<ErrorOr<IEnumerable<RestaurantDto>>>
    {
        public IEnumerable<Guid> RestaurantIds { get; set; } = new List<Guid>();
    }
}

using ErrorOr;
using HangryHub.MainService.Application.Restaurant.DTOs.RestaurantAggregate;
using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using MediatR;

namespace HangryHub.MainService.Application.Restaurant.Query.GetRestaurantList
{
    public class GetRestaurantListQuery : IRequest<ErrorOr<IEnumerable<RestaurantListingDto>>>
    {
        public IEnumerable<Guid> RestaurantIds { get; set; } = new List<Guid>();
    }
}

using ErrorOr;
using HangryHub.MainService.Application.Repository;
using HangryHub.MainService.Application.Restaurant.DTOs;
using HangryHub.MainService.Application.Restaurant.Query.GetRestaurant;
using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Application.Restaurant.Query.GetRestaurantList
{
    public class GetRestaurantListQueryHandler : IRequestHandler<GetRestaurantListQuery, ErrorOr<IEnumerable<RestaurantDto>>>
    {
        private readonly IRestaurantAggregateRepository _restaurantRepository;

        public GetRestaurantListQueryHandler(IRestaurantAggregateRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<ErrorOr<IEnumerable<RestaurantDto>>> Handle(GetRestaurantListQuery request, CancellationToken cancellationToken)
        {
            var restaurant = await _restaurantRepository.GetWithAllRelatedEntitiesAsync(request.RestaurantIds.Select(a => new RestaurantId(a)).ToArray());

            if (restaurant == null || !restaurant.Any())
            {
                return Error.NotFound();
            }

            return restaurant.Adapt<List<RestaurantDto>>();
        }
    }
}

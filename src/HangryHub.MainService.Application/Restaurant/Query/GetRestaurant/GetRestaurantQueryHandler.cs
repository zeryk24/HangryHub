﻿using ErrorOr;
using HangryHub.MainService.Application.Repository;
using HangryHub.MainService.Application.Restaurant.DTOs;
using Mapster;
using MediatR;

namespace HangryHub.MainService.Application.Restaurant.Query.GetRestaurant
{
    public class GetRestaurantQueryHandler : IRequestHandler<GetRestaurantQuery, ErrorOr<RestaurantDto>>
    {
        private readonly IRestaurantAggregateRepository _restaurantRepository;

        public GetRestaurantQueryHandler(IRestaurantAggregateRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<ErrorOr<RestaurantDto>> Handle(GetRestaurantQuery request, CancellationToken cancellationToken)
        {
            var restaurant = await _restaurantRepository.FindByIdWithAllRelatedEntitiesAsync(request.RestaurantId);
            
            if (restaurant == null)
            {
                return Error.NotFound();
            }

            return restaurant.Adapt<RestaurantDto>();
        }
    }
}

using ErrorOr;
using HangryHub.MainService.Application.Repository;
using HangryHub.MainService.Application.Restaurant.DTOs;
using HangryHub.MainService.Domain.RestaurantAggregate.Entities;
using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Application.Restaurant.Command.AddRestaurantItem
{
    public class AddRestaurantItemCommandHandler : IRequestHandler<AddRestaurantItemCommand, ErrorOr<RestaurantDto>>
    {
        private readonly IRepository<Domain.RestaurantAggregate.Restaurant> _restaurantRepository;

        public AddRestaurantItemCommandHandler(IRepository<Domain.RestaurantAggregate.Restaurant> restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<ErrorOr<RestaurantDto>> Handle(AddRestaurantItemCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await _restaurantRepository.GetByIdAsync(request.RestaurantId);

            // if you see a warning ... VS is a retard here ...
            if (restaurant == null)
            {
                return Error.NotFound();
            }

            foreach (var item in request.RestaurantItems)
            {
                var restaurantItemId = new RestaurantItemId(Guid.NewGuid());

                var restaurantItem = new RestaurantItem(restaurantItemId)
                {
                    RestaurantId = restaurant.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Ingredients = item.Ingredients
                        .Select(i => new Ingredient(new IngredientId(Guid.NewGuid())) 
                        { 
                            Name = i.Name, 
                            RestaurantItemId = restaurantItemId 
                        })
                        .ToList(),

                    AdditionalIngredients = item.AdditionalIngredients
                        .Select(ai => new AdditionalIngredient(new AdditionalIngredientId(Guid.NewGuid())) 
                        {
                            Name = ai.Name,
                            Price = ai.Price,
                            RestaurantItemId = restaurantItemId 
                        })
                        .ToList()
                };

                restaurant.Items = restaurant.Items.Append(restaurantItem);
            }

            await _restaurantRepository.SaveChangesAsync();

            return restaurant.Adapt<RestaurantDto>();
        }
    }
}

using ErrorOr;
using HangryHub.MainService.Application.Repository;
using HangryHub.MainService.Application.Restaurant.DTOs;
using Mapster;
using MediatR;

namespace HangryHub.MainService.Application.Restaurant.Command.CreateRestaurant
{
    public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, ErrorOr<RestaurantDto>>
    {
        private readonly IRepository<Domain.RestaurantAggregate.Restaurant> _restaurantRepository;

        public CreateRestaurantCommandHandler(IRepository<Domain.RestaurantAggregate.Restaurant> restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<ErrorOr<RestaurantDto>> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurantId = new Domain.RestaurantAggregate.ValueObjects.RestaurantId(Guid.NewGuid());
            
            var detail = new Domain.RestaurantAggregate.Entities.RestaurantDetail()
            {
                Address = request.Address,
                Contact = request.Contact,
                Note = request.Note,
            };

            var restaurant = new Domain.RestaurantAggregate.Restaurant(restaurantId)
            {
                Name = request.Name,
                Detail = detail,
            };

            _restaurantRepository.Insert(restaurant);

            await _restaurantRepository.SaveChangesAsync();

            return restaurant.Adapt<RestaurantDto>();
        }
    }
}

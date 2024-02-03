using ErrorOr;
using HangryHub.MainService.Application.Repository;
using MediatR;

namespace HangryHub.MainService.Application.Restaurant.Command.CreateRestaurant
{
    internal class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, ErrorOr<Domain.RestaurantAggregate.Restaurant>>
    {
        private readonly IRepository<Domain.RestaurantAggregate.Restaurant> _restaurantRepository;
        private readonly IRepository<Domain.RestaurantAggregate.Entities.RestaurantLocation> _restaurantLocationRepository;

        public CreateRestaurantCommandHandler(IRepository<Domain.RestaurantAggregate.Restaurant> restaurantRepository, IRepository<Domain.RestaurantAggregate.Entities.RestaurantLocation> restaurantLocationRepository)
        {
            _restaurantRepository = restaurantRepository;
            _restaurantLocationRepository = restaurantLocationRepository;
        }

        public async Task<ErrorOr<Domain.RestaurantAggregate.Restaurant>> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurantId = new Domain.RestaurantAggregate.ValueObjects.RestaurantId(Guid.NewGuid());
            var restaurantLocationId = new Domain.RestaurantAggregate.ValueObjects.RestaurantLocationId(Guid.NewGuid());
            var location = new Domain.RestaurantAggregate.Entities.RestaurantLocation()
            {
                AddressLine1 = request.AddressLine1,
                AddressLine2 = request.AddressLine2,
                Country = request.Country,
            };

            var restaurant = new Domain.RestaurantAggregate.Restaurant(restaurantId.Value)
            {
                Name = request.Name,
                Location = location,
            };

            _restaurantLocationRepository.Insert(location);
            _restaurantRepository.Insert(restaurant);

            await _restaurantRepository.SaveChangesAsync();

            return default;
        }
    }
}

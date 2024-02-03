using ErrorOr;
using HangryHub.MainService.Application.Repository;
using MediatR;

namespace HangryHub.MainService.Application.Restaurant.Command.CreateRestaurant
{
    internal class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, ErrorOr<Domain.RestaurantAggregate.Restaurant>>
    {
        private readonly IRepository<Domain.RestaurantAggregate.Restaurant> _restaurantRepository;

        public CreateRestaurantCommandHandler(IRepository<Domain.RestaurantAggregate.Restaurant> restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
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

            _restaurantRepository.Insert(restaurant);

            await _restaurantRepository.SaveChangesAsync();

            return restaurant;
        }
    }
}

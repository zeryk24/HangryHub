using ErrorOr;
using MediatR;

namespace HangryHub.MainService.Application.Restaurant.Command.CreateRestaurant
{
    public record CreateRestaurantCommand(string Name, string AddressLine1, string AddressLine2, string Country) : IRequest<ErrorOr<Domain.RestaurantAggregate.Restaurant>>;
}

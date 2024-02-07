using ErrorOr;
using HangryHub.MainService.Application.Restaurant.DTOs.RestaurantAggregate;
using MediatR;

namespace HangryHub.MainService.Application.Restaurant.Command.CreateRestaurant
{
    public class CreateRestaurantCommand : IRequest<ErrorOr<RestaurantDto>>
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string Contact { get; set; }
        public required string Note { get; set; }
    }
}

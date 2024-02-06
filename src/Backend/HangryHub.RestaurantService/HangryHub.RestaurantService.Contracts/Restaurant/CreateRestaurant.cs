using HangryHub.RestaurantService.Contracts.Restaurant.Models;

namespace HangryHub.RestaurantService.Contracts.Restaurant;

public record CreateRestaurantRequest(RestaurantModel Restaurant);

public record CreateRestaurantResponse(RestaurantIdModel Restaurant);

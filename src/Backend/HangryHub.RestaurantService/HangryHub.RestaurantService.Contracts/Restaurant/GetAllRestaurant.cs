using FastEndpoints;
using HangryHub.RestaurantService.Contracts.Restaurant.Models;
using System.ComponentModel;

namespace HangryHub.RestaurantService.Contracts.Restaurant;

public record GetAllRestaurantRequest
{
    [FromHeader(IsRequired = false)]
    public int PageNumber { get; set; }

    [FromHeader(IsRequired = false)]
    public int PageSize { get; set; }
}

public record GetAllRestaurantResponse(IEnumerable<RestaurantIdModel> Restaurants);

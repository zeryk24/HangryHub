﻿using HangryHub.RestaurantService.Application.RestaurantRequests.Commands;
using HangryHub.RestaurantService.Application.RestaurantRequests.Queries;
using HangryHub.RestaurantService.Contracts.Restaurant;
using Riok.Mapperly.Abstractions;

namespace HangryHub.RestaurantService.Presentation.Restaurant;

[Mapper(UseDeepCloning = true)]
public static partial class RestaurantMapper
{
    public static partial CreateRestaurantCommand MapToCommand(this CreateRestaurantRequest request);
    public static partial CreateRestaurantResponse MapToResponse(this CreateRestaurantCommand.Result result);

    public static partial GetAllRestaurantQuery MapToQuery(this GetAllRestaurantRequest request);
    public static partial GetAllRestaurantResponse MapToResponse(this GetAllRestaurantQuery.Result result);
}

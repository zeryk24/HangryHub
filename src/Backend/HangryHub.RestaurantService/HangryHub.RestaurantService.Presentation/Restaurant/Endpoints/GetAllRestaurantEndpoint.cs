using FastEndpoints;
using HangryHub.RestaurantService.Application.RestaurantRequests.Queries;
using HangryHub.RestaurantService.Contracts.Restaurant;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HangryHub.RestaurantService.Presentation.Restaurant.Endpoints;

public class GetAllRestaurantEndpoint(ISender _sender) : Endpoint<GetAllRestaurantRequest, IResult>
{
    public override void Configure()
    {
        Get("/Restaurants");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetAllRestaurantRequest request, CancellationToken cancellationToken)
    {
        GetAllRestaurantQuery query = request.MapToQuery();

        var result = await _sender.Send(query, cancellationToken);

        var response = result.Match(
            r => Results.Ok(result.Value.MapToResponse()),
            errors => Results.BadRequest(errors)
            );

        await SendAsync(response);
    }
}

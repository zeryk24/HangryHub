using FastEndpoints;
using HangryHub.RestaurantService.Application.RestaurantRequests.Commands;
using HangryHub.RestaurantService.Contracts.Restaurant;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HangryHub.RestaurantService.Presentation.Restaurant.Endpoints;

public class CreateRestaurantEndpoint(ISender _sender) : Endpoint<CreateRestaurantRequest, CreateRestaurantResponse>
{
    public override void Configure()
    {
        Post("/Restaurant");
        AllowAnonymous();
    }

    public override async Task<IResult> HandleAsync(CreateRestaurantRequest request, CancellationToken cancellationToken)
    {
        CreateRestaurantCommand command = request.MapToCommand();

        var result = await _sender.Send(command, cancellationToken);

        return result.Match(
            r => Results.Ok(result.Value.MapToResponse()),
            errors => Results.BadRequest(errors)
            );
    }
}

using FastEndpoints;
using HangryHub.RestaurantService.Application.RestaurantRequests.Commands;
using HangryHub.RestaurantService.Contracts.Restaurant;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HangryHub.RestaurantService.Presentation.Restaurant.Endpoints;

public class CreateRestaurantEndpoint(ISender _sender) : Endpoint<CreateRestaurantRequest, IResult>
{
    public override void Configure()
    {
        Post("/Restaurant");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateRestaurantRequest request, CancellationToken cancellationToken)
    {
        CreateRestaurantCommand command = request.MapToCommand();

        var result = await _sender.Send(command, cancellationToken);

        var response = result.Match(
            r => Results.Ok(result.Value.MapToResponse()),
            errors => Results.BadRequest(errors)
            );

        await SendAsync(response);
    }
}

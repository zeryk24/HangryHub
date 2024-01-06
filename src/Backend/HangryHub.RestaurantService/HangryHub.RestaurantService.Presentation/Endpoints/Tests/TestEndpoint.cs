using ErrorOr;
using FastEndpoints;
using HangryHub.RestaurantService.Application.Tests.Queries;
using HangryHub.RestaurantService.Contracts.Test;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HangryHub.RestaurantService.Presentation.Endpoints.Tests;

public class TestEndpoint(ISender sender) : Endpoint<TestRequest, TestResponse>
{
    public override void Configure()
    {
        Post("/api/test/");
        AllowAnonymous();
    }

    public override async Task HandleAsync(TestRequest request, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new TestQuery(request.FirstName, request.LastName, request.Age));

        var response = result.Match(
            value => new TestResponse() { FullName = value.FullName, IsOver18 = value.IsOver18 },
            errors => new TestResponse());

        await SendAsync(response);
    }
}

using FastEndpoints;
using HangryHub.RestaurantService.Application.RestaurantRequests.Commands;
using MediatR;

namespace HangryHub.RestaurantService.Presentation.Restaurant.Endpoints
{
    public class TestRestaurantItemEndpoint(ISender _sender) : Endpoint<EmptyRequest, EmptyResponse>
    {
        public override void Configure()
        {
            Post("/Restaurant/TestRestaurantItem");
            AllowAnonymous();
        }

        public override async Task HandleAsync(EmptyRequest request, CancellationToken cancellationToken)
        {
            await _sender.Send(new TestRestaurantItemCommand(), cancellationToken);
        }
    }
}

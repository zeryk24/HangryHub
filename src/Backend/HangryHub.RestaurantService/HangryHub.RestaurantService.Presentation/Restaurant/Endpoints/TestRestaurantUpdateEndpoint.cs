using FastEndpoints;
using HangryHub.RestaurantService.Application.RestaurantRequests.Commands;
using MediatR;

namespace HangryHub.RestaurantService.Presentation.Restaurant.Endpoints
{
    public class TestRestaurantUpdateEndpoint(ISender _sender) : Endpoint<EmptyRequest, EmptyResponse>
    {
        public override void Configure()
        {
            Post("/Restaurant/TestRestaurantUpdate");
            AllowAnonymous();
        }

        public override async Task HandleAsync(EmptyRequest request, CancellationToken cancellationToken)
        {
            await _sender.Send(new TestUpdateRestaurantCommand(), cancellationToken);
        }
    }
}

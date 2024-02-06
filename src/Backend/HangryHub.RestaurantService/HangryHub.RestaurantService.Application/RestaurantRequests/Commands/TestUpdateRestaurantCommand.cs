using HangryHub.RestaurantService.Contracts.Restaurant.Messages;
using MassTransit;
using MediatR;

namespace HangryHub.RestaurantService.Application.RestaurantRequests.Commands;

public record TestUpdateRestaurantCommand() : IRequest
{
    
}

public class TestUpdateRestaurantHandler : IRequestHandler<TestUpdateRestaurantCommand>
{
    private IPublishEndpoint publishEndpoint;

    public TestUpdateRestaurantHandler(IPublishEndpoint publishEndpoint)
    {
        this.publishEndpoint = publishEndpoint;
    }

    public async Task Handle(TestUpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        await publishEndpoint.Publish<RestaurantUpdateMessage>(new()
        {
            RestaurantId = Guid.NewGuid(),
            RestaurantName = "Caticorn",
            Address = "Cat street1, Caticornov",
            Contact = "Meow twice",
            Note = "With polite intonation",
        });
    }
}

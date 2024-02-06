using HangryHub.RestaurantService.Contracts.Restaurant.Messages;
using MassTransit;
using MediatR;

namespace HangryHub.RestaurantService.Application.RestaurantRequests.Commands;

public record TestCouponCommand() : IRequest
{
}

public class TestCouponHandler : IRequestHandler<TestCouponCommand>
{
    private IPublishEndpoint publishEndpoint;

    public TestCouponHandler(IPublishEndpoint publishEndpoint)
    {
        this.publishEndpoint = publishEndpoint;
    }

    public async Task Handle(TestCouponCommand request, CancellationToken cancellationToken)
    {
        await publishEndpoint.Publish<RestaurantCouponUpdateMessage>(new()
        {
            Id = Guid.NewGuid(),
            Name = "Catnip 3000",
            EuroPrice = 10.0,
            ExpirationDate = DateTime.Now.AddDays(10),
        });
    }
}

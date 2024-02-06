using HangryHub.RestaurantService.Contracts.Restaurant.Messages;
using MassTransit;
using MediatR;

namespace HangryHub.RestaurantService.Application.RestaurantRequests.Commands;

public record TestRestaurantItemCommand() : IRequest
{
}

public class TestRestaurantItemHandler : IRequestHandler<TestRestaurantItemCommand>
{
    private IPublishEndpoint publishEndpoint;

    public TestRestaurantItemHandler(IPublishEndpoint publishEndpoint)
    {
        this.publishEndpoint = publishEndpoint;
    }

    public async Task Handle(TestRestaurantItemCommand request, CancellationToken cancellationToken)
    {
        await publishEndpoint.Publish<RestaurantItemUpdateMessage>(new()
        {
            Id = Guid.NewGuid(),
            RestaurantItems = new List<RestaurantItemMessage>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Fish from akvarium",
                    EuroPrice = 10.0,
                    Description = "The best catnip in the world",
                    Ingredients = new List<RestaurantItemIngredient>
                    {
                        new()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Chicken filling",
                        },
                    },
                    ExtraIngredients = new List<RestaurantItemExtraIngredient>
                    {
                        new()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Lucky scale",
                            Price = 1.0,
                        },
                    },
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Milk",
                    EuroPrice = 1.0,
                    Description = "Fresh milk",
                    Ingredients = new List<RestaurantItemIngredient>
                    {
                        new()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Paw cookie",
                        },
                    },
                    ExtraIngredients = new List<RestaurantItemExtraIngredient>
                    {
                        new()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Catnip sprincle",
                            Price = 0.5,
                        },
                    }
                },
            }   
        });
    }
}

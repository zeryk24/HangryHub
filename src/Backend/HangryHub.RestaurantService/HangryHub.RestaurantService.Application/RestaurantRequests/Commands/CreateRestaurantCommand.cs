using ErrorOr;
using HangryHub.RestaurantService.Application.Common.Persistance;
using HangryHub.RestaurantService.Application.RestaurantRequests.Models;
using HangryHub.RestaurantService.Domain.RestaurantAggregate;
using HangryHub.RestaurantService.Domain.RestaurantAggregate.Entities.IngredientEntity;
using HangryHub.RestaurantService.Domain.RestaurantAggregate.Entities.IngredientEntity.ValueObjects;
using HangryHub.RestaurantService.Domain.RestaurantAggregate.Entities.MenuItemEntity;
using HangryHub.RestaurantService.Domain.RestaurantAggregate.Entities.MenuItemEntity.ValueObjects;
using HangryHub.RestaurantService.Domain.RestaurantAggregate.ValueObjects;
using MediatR;
using System.Data;

namespace HangryHub.RestaurantService.Application.RestaurantRequests.Commands;

public record CreateRestaurantCommand(RestaurantModel restaurant) : IRequest<ErrorOr<CreateRestaurantCommand.Result>>
{
    public record Result(RestaurantIdModel Restaurant);
}

public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, ErrorOr<CreateRestaurantCommand.Result>>
{
    private readonly IRepository<Restaurant> _repository;

    public CreateRestaurantCommandHandler(IRepository<Restaurant> repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<CreateRestaurantCommand.Result>> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = request.restaurant;

        var id = RestaurantId.CreateUnique();
        var name = RestaurantName.Create(restaurant.Name);
        var description = RestaurantDescription.Create(restaurant.Description);
        var menuItems = RestaurantMapper.CreateMenuItems(restaurant.MenuItems);

        var newRestaurant = Restaurant.Create(id, name, description, menuItems);

        var createdRestaurant = await _repository.InsertAsync(newRestaurant, cancellationToken);
        await _repository.CommitAsync();

        return new CreateRestaurantCommand.Result(RestaurantMapper.MapRestaurantToModel(createdRestaurant));

    }
}

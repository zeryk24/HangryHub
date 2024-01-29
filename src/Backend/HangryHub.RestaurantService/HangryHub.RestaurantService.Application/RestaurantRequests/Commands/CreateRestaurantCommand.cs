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
        var menuItems = CreateMenuItems(restaurant.MenuItems);

        var newRestaurant = Restaurant.Create(id, name, description, menuItems);

        var createdRestaurant = await _repository.InsertAsync(newRestaurant, cancellationToken);
        await _repository.CommitAsync();

        return new CreateRestaurantCommand.Result(MapRestaurantToModel(createdRestaurant));

    }

    private List<MenuItem> CreateMenuItems(IEnumerable<MenuItemModel> menuItemModels)
    {
        List<MenuItem> menuItems = new();

        foreach (var menuItemModel in menuItemModels)
        {
            var id = MenuItemId.CreateUnique();
            var name = MenuItemName.Create(menuItemModel.Name);
            var description = MenuItemDescription.Create(menuItemModel.Description);
            var price = MenuItemPrice.Create(menuItemModel.PriceCzk);
            var ingredients = CreateIngredients(menuItemModel.ingredients);

            var newMenuItem = MenuItem.Create(id, name, description, price, ingredients);

            menuItems.Add(newMenuItem);
        }

        return menuItems;
    }

    private List<Ingredient> CreateIngredients(IEnumerable<IngredientModel> ingredientModels)
    {
        List<Ingredient> ingredients = new();

        foreach (var ingredientModel in ingredientModels)
        {
            var id = IngredientId.CreateUnique();
            var name = IngredientName.Create(ingredientModel.Name);
            var weight = IngredientWeight.Create(ingredientModel.Grams);

            var newIngredient = Ingredient.Create(id, name, weight);

            ingredients.Add(newIngredient);
        }

        return ingredients;
    }

    private RestaurantIdModel MapRestaurantToModel(Restaurant restaurant)
    {
        return new(
            restaurant.Id.Value,
            restaurant.Name.Value,
            restaurant.Description.Value,
            restaurant.MenuItems.Select(MapMenuItemToModel)
       );
    }

    private MenuItemIdModel MapMenuItemToModel(MenuItem menuItem)
    {
        return new(
            menuItem.Id.Value,
            menuItem.Name.Value,
            menuItem.Description.Value,
            menuItem.Price.Czk,
            menuItem.Ingredients.Select(MapIngredientToModel)
       );
    }

    private IngredientModel MapIngredientToModel(Ingredient ingredient)
    {
        return new(
            ingredient.Name.Value,
            ingredient.Weight.Grams
       );
    }
}

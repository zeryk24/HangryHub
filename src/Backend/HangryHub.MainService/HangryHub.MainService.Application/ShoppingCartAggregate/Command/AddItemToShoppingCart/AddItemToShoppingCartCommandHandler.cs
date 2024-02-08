using ErrorOr;
using HangryHub.MainService.Application.Repository;
using HangryHub.MainService.Application.Restaurant.DTOs.RestaurantAggregate;
using HangryHub.MainService.Application.Restaurant.DTOs.ShoppingCartAggregate;
using HangryHub.MainService.Application.ShoppingCartAggregate.Command.SetDeliveryAddress;
using HangryHub.MainService.Domain.RestaurantAggregate.Entities;
using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using HangryHub.MainService.Domain.ShoppingCartAggregate.Entities;
using HangryHub.MainService.Domain.ShoppingCartAggregate.ValueObjects;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HangryHub.MainService.Application.ShoppingCartAggregate.Command.AddItemToShoppingCart
{
    public class AddItemToShoppingCartCommandHandler : IRequestHandler<AddItemToShoppingCartCommand, ErrorOr<ShoppingCartDto>>
    {
        private readonly IRestaurantAggregateRepository _restaurantRepository;
        private readonly IRepository<ShoppingCartItem> _shoppingCartItemRepository;
        private readonly IShoppingCartAggregateRepository _shoppingCartAggregateRepository;

        public AddItemToShoppingCartCommandHandler(IRestaurantAggregateRepository restaurantRepository, IShoppingCartAggregateRepository shoppingCartAggregateRepository, IRepository<ShoppingCartItem> shoppingCartItemRepository)
        {
            _restaurantRepository = restaurantRepository;
            _shoppingCartAggregateRepository = shoppingCartAggregateRepository;
            _shoppingCartItemRepository = shoppingCartItemRepository;
        }

        public async Task<ErrorOr<ShoppingCartDto>> Handle(AddItemToShoppingCartCommand request, CancellationToken cancellationToken)
        {
            var shoppingCartId = new ShoppingCartId(request.ShoppingCartId);
            var shoppingCart = await _shoppingCartAggregateRepository.GetWithDetailsAsync(shoppingCartId);

            // if you see a warning ... VS is a retard here ...
            if (shoppingCart == null)
            {
                return Error.NotFound();
            }

            var restaurantItemId = new RestaurantItemId(request.Item.RestaurantItemId);
            var restaurantItem = await _restaurantRepository.GetrRestaurantItemWithDetailsAsync(restaurantItemId);

            if (restaurantItem == null)
            {
                return Error.NotFound();
            }

            var shoppingCartItem = restaurantItem.Adapt<ShoppingCartItem>();

            var restaurantItemQuantity = request.Item.RestaurantItemQuantity;

            var additionalIngredients = request.Item.AdditionalIngredients
                .GroupBy(a => a.AdditionalIngredientId)
                .ToDictionary(x => x.Key, y => y.Select(a => a.AdditionalIngredientQuantity).Sum());

            var existingAdditionalIng = restaurantItem.AdditionalIngredients
                .Where(a => additionalIngredients.Select(a => a.Key).Contains(a.Id.Value))
                .ToList();

            var saiList = new List<SelectedAdditionalIngredient>();

            foreach (var additionalIngredient in existingAdditionalIng)
            {
                var selectedAdditionalIngredient = additionalIngredient.Adapt<SelectedAdditionalIngredient>();
                selectedAdditionalIngredient.Quantity = additionalIngredients[additionalIngredient.Id.Value];

                shoppingCartItem.Price += (additionalIngredient.Price * selectedAdditionalIngredient.Quantity);
                saiList.Add(selectedAdditionalIngredient);
            }

            shoppingCartItem.SelectedAdditionalIngredients = saiList;

            _shoppingCartItemRepository.Insert(shoppingCartItem);
            await _shoppingCartItemRepository.SaveChangesAsync();

            return shoppingCart.Adapt<ShoppingCartDto>();
        }
    }
}

using ErrorOr;
using HangryHub.MainService.Application.DTOs.ShoppingCartAggregate;
using HangryHub.MainService.Application.Repository;
using HangryHub.MainService.Domain.ShoppingCartAggregate.Entities;
using HangryHub.MainService.Domain.ShoppingCartAggregate.ValueObjects;
using Mapster;
using MediatR;

namespace HangryHub.MainService.Application.ShoppingCartAggregate.Command.RemoveItemFromShoppingCart
{
    internal class RemoveItemFromShoppingCartCommandHandler
    {
    }

    public class AddItemToShoppingCartCommandHandler : IRequestHandler<RemoveItemFromShoppingCartCommand, ErrorOr<ShoppingCartDto>>
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

        public async Task<ErrorOr<ShoppingCartDto>> Handle(RemoveItemFromShoppingCartCommand request, CancellationToken cancellationToken)
        {
            var shoppingCartId = new ShoppingCartId(request.ShoppingCartId);
            var shoppingCart = await _shoppingCartAggregateRepository.GetWithDetailsAsync(shoppingCartId);

            // if you see a warning ... VS is a retard here ...
            if (shoppingCart == null)
            {
                return Error.NotFound();
            }

            var shoppingCartItemId = new ShoppingCartItemId(request.ShoppingCartItemId);

            if (!await _shoppingCartItemRepository.RemoveAsync(shoppingCartItemId))
            {
                return Error.NotFound();
            }

            await _shoppingCartItemRepository.SaveChangesAsync();

            return shoppingCart.Adapt<ShoppingCartDto>();
        }
    }
}

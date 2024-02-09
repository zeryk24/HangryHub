using ErrorOr;
using MediatR;
using HangryHub.MainService.Application.DTOs.ShoppingCartAggregate;

namespace HangryHub.MainService.Application.ShoppingCartAggregate.Command.RemoveItemFromShoppingCart
{
    public class RemoveItemFromShoppingCartCommand : IRequest<ErrorOr<ShoppingCartDto>>
    {
        public required Guid ShoppingCartId { get; set; }

        public required Guid ShoppingCartItemId { get; set; }
    }
}

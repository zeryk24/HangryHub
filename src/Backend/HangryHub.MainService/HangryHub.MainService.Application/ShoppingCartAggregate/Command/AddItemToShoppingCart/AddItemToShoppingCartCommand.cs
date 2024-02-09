using ErrorOr;
using HangryHub.MainService.Application.DTOs.ShoppingCartAggregate;
using HangryHub.MainService.Application.DTOs.ShoppingCartAggregate.Request;
using MediatR;

namespace HangryHub.MainService.Application.ShoppingCartAggregate.Command.AddItemToShoppingCart
{
    public class AddItemToShoppingCartCommand : IRequest<ErrorOr<ShoppingCartDto>>
    {
        public required Guid ShoppingCartId { get; set; }

        public required ShoppingCartItemAdditionDTO Item { get; set; }
    }
}

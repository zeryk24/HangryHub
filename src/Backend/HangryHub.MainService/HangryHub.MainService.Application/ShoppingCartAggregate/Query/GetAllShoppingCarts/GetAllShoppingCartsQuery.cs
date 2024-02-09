using ErrorOr;
using HangryHub.MainService.Application.DTOs.ShoppingCartAggregate;
using MediatR;

namespace HangryHub.MainService.Application.ShoppingCartAggregate.Query.GetAllShoppingCarts
{
    public class GetAllShoppingCartsQuery : IRequest<ErrorOr<List<ShoppingCartDto>>>
    {
    }
}

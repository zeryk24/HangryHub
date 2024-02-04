using ErrorOr;
using HangryHub.MainService.Application.Restaurant.DTOs.RestaurantAggregate;
using HangryHub.MainService.Application.Restaurant.DTOs.ShoppingCartAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Application.ShoppingCartAggregate.Query.GetAllShoppingCarts
{
    public class GetAllShoppingCartsQuery : IRequest<ErrorOr<List<ShoppingCartDto>>>
    {
    }
}

using ErrorOr;
using HangryHub.MainService.Application.Restaurant.DTOs.RestaurantAggregate;
using HangryHub.MainService.Application.Restaurant.DTOs.ShoppingCartAggregate;
using HangryHub.MainService.Application.Restaurant.DTOs.ShoppingCartAggregate.Request;
using HangryHub.MainService.Domain.RestaurantAggregate.Entities;
using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Application.ShoppingCartAggregate.Command.AddItemToShoppingCart
{
    public class AddItemToShoppingCartCommand : IRequest<ErrorOr<ShoppingCartDto>>
    {
        public required Guid ShoppingCartId { get; set; }

        public required ShoppingCartItemAdditionDTO Item { get; set; }
    }
}

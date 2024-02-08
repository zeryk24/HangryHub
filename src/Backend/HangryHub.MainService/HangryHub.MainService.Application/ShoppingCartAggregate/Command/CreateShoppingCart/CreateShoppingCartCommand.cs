using ErrorOr;
using HangryHub.MainService.Application.Restaurant.DTOs.ShoppingCartAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Application.ShoppingCartAggregate.Command.CreateShoppingCart
{
    public class CreateShoppingCartCommand : IRequest<ErrorOr<ShoppingCartDto>>
    {
        public required Guid RestaurantId { get; set; }
        public required Guid CustomerId { get; set; }
    }
}

using ErrorOr;
using HangryHub.MainService.Application.Repository;
using HangryHub.MainService.Application.Restaurant.DTOs.ShoppingCartAggregate;
using HangryHub.MainService.Application.ShoppingCartAggregate.Query.GetAllShoppingCarts;
using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using HangryHub.MainService.Domain.ShoppingCartAggregate.ValueObjects;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Application.ShoppingCartAggregate.Query.GetUserShoppingCart
{
    public class GetUserShoppingCartQueryHandler : IRequestHandler<GetUserShoppingCartQuery, ErrorOr<ShoppingCartDto>>
    {
        private readonly IShoppingCartAggregateRepository _repository;

        public GetUserShoppingCartQueryHandler(IShoppingCartAggregateRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<ShoppingCartDto>> Handle(GetUserShoppingCartQuery request, CancellationToken cancellationToken)
        {
            var restaurantId = new RestaurantId(request.RestaurantId);
            var customerId = new CustomerId(request.CustomerId);

            var shoppingCart = await _repository.GetActiveCartForUser(customerId, restaurantId);

            if (shoppingCart == null)
            {
                return Error.NotFound();
            }

            var dto = shoppingCart.Adapt<ShoppingCartDto>();
            return dto;
        }
    }
}

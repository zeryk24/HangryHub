using ErrorOr;
using HangryHub.MainService.Application.DTOs.ShoppingCartAggregate;
using HangryHub.MainService.Application.Repository;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Application.ShoppingCartAggregate.Query.GetAllShoppingCarts
{
    public class GetAllShoppingCartsQueryHandler : IRequestHandler<GetAllShoppingCartsQuery, ErrorOr<List<ShoppingCartDto>>>
    {
        private readonly IShoppingCartAggregateRepository _repository;

        public GetAllShoppingCartsQueryHandler(IShoppingCartAggregateRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<List<ShoppingCartDto>>> Handle(GetAllShoppingCartsQuery request, CancellationToken cancellationToken)
        {
            var shoppingCarts = await _repository.GetAllWithDetailsAsync();
            var dto = shoppingCarts.Adapt<List<ShoppingCartDto>>();
            return dto;
        }
    }
}

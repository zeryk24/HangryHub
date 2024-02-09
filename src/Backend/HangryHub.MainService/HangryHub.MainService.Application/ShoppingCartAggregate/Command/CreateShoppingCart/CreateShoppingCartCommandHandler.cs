using ErrorOr;
using HangryHub.MainService.Application.DTOs.ShoppingCartAggregate;
using HangryHub.MainService.Application.Repository;
using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using HangryHub.MainService.Domain.ShoppingCartAggregate.Entities;
using HangryHub.MainService.Domain.ShoppingCartAggregate.ValueObjects;
using Mapster;
using MediatR;
namespace HangryHub.MainService.Application.ShoppingCartAggregate.Command.CreateShoppingCart
{
    public class CreateShoppingCartCommandHandler : IRequestHandler<CreateShoppingCartCommand, ErrorOr<ShoppingCartDto>>
    {
        private readonly IRepository<DeliveryData> _deliveryRepository;
        private readonly IShoppingCartAggregateRepository _shoppingCartAggregateRepository;

        public CreateShoppingCartCommandHandler(IRepository<DeliveryData> deliveryRepository, IShoppingCartAggregateRepository shoppingCartAggregateRepository)
        {
            _deliveryRepository = deliveryRepository;
            _shoppingCartAggregateRepository = shoppingCartAggregateRepository;
        }

        public async Task<ErrorOr<ShoppingCartDto>> Handle(CreateShoppingCartCommand request, CancellationToken cancellationToken)
        {
            var restaurantId = new RestaurantId(request.RestaurantId);
            var customerId = new CustomerId(request.CustomerId);

            var shoppingCart = await _shoppingCartAggregateRepository.CreateActiveCartForUser(customerId, restaurantId);

            if (shoppingCart == null)
            {
                return Error.NotFound();
            }

            var dto = shoppingCart.Adapt<ShoppingCartDto>();
            return dto;
        }
    }
}

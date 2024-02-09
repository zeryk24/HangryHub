using ErrorOr;
using HangryHub.MainService.Application.DTOs.ShoppingCartAggregate;
using HangryHub.MainService.Application.Repository;
using HangryHub.MainService.Domain.ShoppingCartAggregate.Entities;
using HangryHub.MainService.Domain.ShoppingCartAggregate.ValueObjects;
using Mapster;
using MediatR;


namespace HangryHub.MainService.Application.ShoppingCartAggregate.Command.SetDeliveryAddress
{
    public class SetDeliveryAddressCommandHandler : IRequestHandler<SetDeliveryAddressCommand, ErrorOr<ShoppingCartDto>>
    {
        private readonly IRepository<DeliveryData> _deliveryRepository;
        private readonly IShoppingCartAggregateRepository _shoppingCartAggregateRepository;

        public SetDeliveryAddressCommandHandler(IRepository<DeliveryData> deliveryRepository, IShoppingCartAggregateRepository shoppingCartAggregateRepository)
        {
            _deliveryRepository = deliveryRepository;
            _shoppingCartAggregateRepository = shoppingCartAggregateRepository;
        }

        public async Task<ErrorOr<ShoppingCartDto>> Handle(SetDeliveryAddressCommand request, CancellationToken cancellationToken)
        {
            var shoppingCartId = new ShoppingCartId(request.ShoppingCartId);
            
            var shoppingCart = await _shoppingCartAggregateRepository.GetWithDetailsAsync(shoppingCartId);

            // if you see a warning ... VS is a retard here ...
            if (shoppingCart == null)
            {
                return Error.NotFound();
            }

            var deliveryData = request.DeliveryData.Adapt<DeliveryData>();

            _deliveryRepository.Insert(deliveryData);
            await _deliveryRepository.SaveChangesAsync();

            shoppingCart.SelectedDeliveryDataId = deliveryData.Id;
            shoppingCart.SelectedDeliveryData = deliveryData;

            _shoppingCartAggregateRepository.Update(shoppingCart);
            await _shoppingCartAggregateRepository.SaveChangesAsync();

            return shoppingCart.Adapt<ShoppingCartDto>();
        }
    }
}

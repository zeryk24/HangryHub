using ErrorOr;
using HangryHub.MainService.Application.DTOs.ShoppingCartAggregate;
using MediatR;

namespace HangryHub.MainService.Application.ShoppingCartAggregate.Command.SetDeliveryAddress
{
    public class SetDeliveryAddressCommand : IRequest<ErrorOr<ShoppingCartDto>>
    {
        public required Guid ShoppingCartId { get; set; }

        public required DeliveryDataDto DeliveryData { get; set; }
    }
}

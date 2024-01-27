using MediatR;
namespace HangryHub.DeliveryService.Application.Delivery.Get
{
    public record GetDeliveryQuery(Guid DeliveryId) : IRequest<DeliveryDTO> { }
  
}

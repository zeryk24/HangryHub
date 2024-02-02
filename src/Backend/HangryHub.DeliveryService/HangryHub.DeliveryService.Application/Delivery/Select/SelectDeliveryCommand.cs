using MediatR;

namespace HangryHub.DeliveryService.Application.Delivery.Select
{

    public class SelectDeliveryCommand : IRequest<bool>
    {
        public Guid DeliveryId { get; private set; }
        public Guid FreelencerId { get; private set; }
        public SelectDeliveryCommand(Guid deliveryId, Guid freelencerId)
        {
            DeliveryId = deliveryId;
            FreelencerId = freelencerId;
        }
    }
}

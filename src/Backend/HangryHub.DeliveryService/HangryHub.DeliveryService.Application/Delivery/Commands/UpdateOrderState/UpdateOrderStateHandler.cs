using HangryHub.DeliveryService.Application.Delivery.Commands.UpdateOrderState;
using MediatR;

namespace HangryHub.DeliveryService.Application.Delivery.Commands.Complete
{
    public class UpdateOrderStateHandler : IRequestHandler<UpdateOrderStateCommand, bool>
    {

        IOrderStateUpdateService orderStateUpdateService;
        public UpdateOrderStateHandler(IOrderStateUpdateService orderStateUpdateService)
        {
            this.orderStateUpdateService = orderStateUpdateService;
        }

        public async Task<bool> Handle(UpdateOrderStateCommand request, CancellationToken cancellationToken)
        {

            Guid? deliveryId = await orderStateUpdateService.FindDeliveryWithOrder(request.OrderId);
            if (deliveryId == null) { return false; }

            await orderStateUpdateService.MakeDeliveryAvaiable((Guid)deliveryId);
            return true;
           
        }
    }
}

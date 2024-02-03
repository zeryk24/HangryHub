using MassTransit;
using MediatR;

namespace HangryHub.DeliveryService.Application.Delivery.DeliveryStateUpdate
{
    public class UpdateDeliveryStateProducer : IRequestHandler<UpdateDeliveryStateCommand>
    {
        IPublishEndpoint _publishEndpoint;
        public UpdateDeliveryStateProducer(IPublishEndpoint publishEndpoint) { 
            _publishEndpoint = publishEndpoint;
        }

        public async Task Handle(UpdateDeliveryStateCommand request, CancellationToken cancellationToken)
        {
            await _publishEndpoint.Publish<DelivetryStateUpdate>(new DelivetryStateUpdate(
                 Guid.NewGuid(),
                 Guid.NewGuid(),
                 "Delivered",
                 DateTime.Now
            ));
        }

    
    }
}

using HangryHub.MainService.Contracts.Messages;
using MassTransit;
using MediatR;

namespace HangryHub.DeliveryService.Application.Delivery.Consumers
{
    public class OrderCreatedConsumer : IConsumer<OrderMessage>
    {
        private readonly IMediator _mediator;
        public OrderCreatedConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task Consume(ConsumeContext<OrderMessage> context)
        {
            throw new NotImplementedException();
        }
    }
}

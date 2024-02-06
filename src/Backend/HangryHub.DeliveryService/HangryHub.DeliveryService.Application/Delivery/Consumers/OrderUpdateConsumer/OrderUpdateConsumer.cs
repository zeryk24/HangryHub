using HangryHub.DeliveryService.Application.Delivery.Commands.Complete;
using HangryHub.OrderService.Contracts.Messages;
using MassTransit;
using MediatR;

namespace HangryHub.DeliveryService.Application.Delivery.Consumers.OrderUpdateConsumer
{
    public class OrderUpdateConsumer : IConsumer<OrderStatusUpdate>
    {
        private readonly IMediator _mediator;
        public OrderUpdateConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }
        public Task Consume(ConsumeContext<OrderStatusUpdate> context)
        {
            Console.WriteLine("Received message: " + context.Message.Status.ToString());
            _mediator.Send(new UpdateOrderStateCommand(context.Message.Id, context.Message.Status));
            return Task.CompletedTask;
        }
    }
}

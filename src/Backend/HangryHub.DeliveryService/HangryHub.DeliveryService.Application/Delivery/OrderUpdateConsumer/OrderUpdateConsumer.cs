using HangryHub.OrderService.Contracts.Messages;
using MassTransit;

namespace HangryHub.DeliveryService.Application.Delivery.OrderUpdateConsumer
{
    public class OrderUpdateConsumer : IConsumer<OrderStatusUpdate>
    {
        public Task Consume(ConsumeContext<OrderStatusUpdate> context)
        {
            Console.WriteLine("Received message: " + context.Message.Status.ToString());
            return Task.CompletedTask;
        }
    }
}

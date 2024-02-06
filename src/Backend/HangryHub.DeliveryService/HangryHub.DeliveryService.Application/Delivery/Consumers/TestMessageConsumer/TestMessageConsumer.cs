using HangryHub.DeliveryService.Application.Delivery.Producers.DeliveryStateUpdate;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.DeliveryService.Application.Delivery.Consumers.TestMessageConsumer
{
    public class TestMessageConsumer : IConsumer<DelivetryStateUpdate>
    {
        public Task Consume(ConsumeContext<DelivetryStateUpdate> context)
        {

            Console.WriteLine("Received message: " + context.Message.Time);
            return Task.CompletedTask;
        }
    }
}

﻿using HangryHub.DeliveryService.Application.Delivery.DeliveryStateUpdate;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.DeliveryService.Application.Delivery.TestMessageConsumer
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

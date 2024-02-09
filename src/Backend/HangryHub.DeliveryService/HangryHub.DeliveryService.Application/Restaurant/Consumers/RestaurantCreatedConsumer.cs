using HangryHub.DeliveryService.Application.Delivery.Commands.Complete;
using HangryHub.DeliveryService.Application.Restaurant.Commands.Create;
using HangryHub.OrderService.Contracts.Messages;
using HangryHub.RestaurantService.Contracts.Restaurant.Messages;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.DeliveryService.Application.Restaurant.Consumers
{
    public class RestaurantCreatedConsumer : IConsumer<RestaurantUpdateMessage>
    {
        private readonly IMediator _mediator;
        public RestaurantCreatedConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }
        public Task Consume(ConsumeContext<RestaurantUpdateMessage> context)
        {
            Console.WriteLine("Received message: " + context.Message.RestaurantName.ToString());
            _mediator.Send(new CreateRestaurantCommand(context.Message));
            return Task.CompletedTask;
        }
    }
}

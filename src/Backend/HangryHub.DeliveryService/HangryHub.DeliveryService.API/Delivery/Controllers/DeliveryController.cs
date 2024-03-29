﻿using HangryHub.DeliveryService.Application.Delivery.Commands.Complete;
using HangryHub.DeliveryService.Application.Delivery.Commands.Pickup;
using HangryHub.DeliveryService.Application.Delivery.Commands.Select;
using HangryHub.DeliveryService.Application.Delivery.Producers.DeliveryStateUpdate;
using HangryHub.DeliveryService.Application.Delivery.Queries.GetNavigation;
using HangryHub.DeliveryService.Application.Delivery.Queries.GetState;
using HangryHub.DeliveryService.Application.Delivery.Queries.ListAvaiable;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HangryHub.DeliveryService.Delivery.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DeliveryController : ControllerBase
    {
        IMediator mediator;
        public DeliveryController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet("Avaiable")]
        public Task<ICollection<ListAvaiableQueryResultItem>> GetAvaiable()
        {
            return mediator.Send(new ListAvaiableQuery());
        }


        [HttpPut("Select")]
        public Task<bool> SelectDelivery(Guid delivery, Guid freelencer)
        {
            return mediator.Send(new SelectDeliveryCommand(delivery,freelencer));
        }


        [HttpGet("State")]
        public Task<GetStateQueryResult> GetDeliveryState(Guid delivery)
        {
            return mediator.Send(new GetStateQuery(delivery));

        }

        [HttpPut("Pickup")]
        public Task<bool> PickupDelivery(Guid delivery)
        {
            return mediator.Send(new PickupDeliveryCommand(delivery));
        }

        [HttpPut("Complete")]
        public Task<bool> CompleteDelivery(Guid delivery)
        {
            return mediator.Send(new CompleteDeliveryCommand(delivery));
        }

        [HttpPut("Cancel")]
        public Task<string> CancelDelivery(Guid delivery)
        {
            throw new NotImplementedException();
        }


        [HttpPost("Review")]
        public Task<string> CreateReview(Guid delivery, string review)
        {
            throw new NotImplementedException();
        }

        [HttpGet("Navigation")]
        public Task<NavigationData> GetNavigationData(Guid delivery)
        {
            return mediator.Send(new GetNavigationQuery(delivery));
        }


        [HttpGet("TestBus")]
        public Task SendTestMessageToBus()
        {
            mediator.Send(new UpdateDeliveryStateCommand());
            return Task.CompletedTask;
        }








    }
}

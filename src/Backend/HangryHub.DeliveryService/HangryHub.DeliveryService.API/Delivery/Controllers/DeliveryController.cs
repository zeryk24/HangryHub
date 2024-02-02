using HangryHub.DeliveryService.Application.Delivery;
using HangryHub.DeliveryService.Application.Delivery.Get;
using HangryHub.DeliveryService.Application.Delivery.GetNavigation;
using HangryHub.DeliveryService.Application.Delivery.GetState;
using HangryHub.DeliveryService.Application.Delivery.ListAvaiable;
using HangryHub.DeliveryService.Application.Delivery.Select;
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








    }
}

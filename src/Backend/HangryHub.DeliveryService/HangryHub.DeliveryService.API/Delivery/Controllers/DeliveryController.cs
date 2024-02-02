using HangryHub.DeliveryService.Application.Delivery;
using HangryHub.DeliveryService.Application.Delivery.Get;
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
        public Task<string> GetDeliveryState(Guid delivery)
        {
            throw new NotImplementedException();

        }

        [HttpPut("Pickup")]
        public Task<string> PickupDelivery(Guid delivery)
        {
            throw new NotImplementedException();
          
        }

        [HttpPut("Deliver")]
        public Task<string> DeliveryDelivered(Guid delivery)
        {
            throw new NotImplementedException();
        }

        [HttpPut("Cancel")]
        public Task<string> CancelDelivery(Guid delivery)
        {
            throw new NotImplementedException();
        }


        [HttpPost("Review")]
        public Task<string> CreateReviwe(Guid delivery, string review)
        {
            throw new NotImplementedException();
        }








    }
}

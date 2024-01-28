using HangryHub.DeliveryService.Application.Delivery;
using HangryHub.DeliveryService.Application.Delivery.Get;
using HangryHub.DeliveryService.Application.Delivery.ListAvaiable;
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

 
    }
}

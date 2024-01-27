using HangryHub.DeliveryService.Application.Delivery;
using HangryHub.DeliveryService.Application.Delivery.Get;
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

        [HttpGet]
        public Task<DeliveryDTO> Get()
        {
            return mediator.Send(new GetDeliveryQuery(Guid.Empty));
        }
    }
}

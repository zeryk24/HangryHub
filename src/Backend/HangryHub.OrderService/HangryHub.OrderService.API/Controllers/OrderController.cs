using HangryHub.OderService.UseCases.Order;
using HangryHub.OderService.UseCases.Order.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HangryHub.OrderService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public Task<OrderDTO> Get()
        {
            return mediator.Send(new GetOrderByIdQuery(new Guid()));
        }
    }
}
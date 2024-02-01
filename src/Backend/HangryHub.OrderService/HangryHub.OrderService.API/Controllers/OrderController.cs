using HangryHub.OderService.UseCases.Order;
using HangryHub.OderService.UseCases.Order.Accept;
using HangryHub.OderService.UseCases.Order.Create;
using HangryHub.OderService.UseCases.Order.Decline;
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
        public async Task<OrderDTO> Get()
        {
            return await mediator.Send(new GetOrderByIdQuery(new Guid()));
        }

        [HttpPost]
        public async Task<OrderDTO> Create(double price)
        {
            return await mediator.Send(new CreateOrderCommand(price));
        }

        [HttpPut("Accept")]
        public async Task<ActionResult<OrderDTO>> Accept(Guid id)
        {
            var orderResult = await mediator.Send(new AcceptOrderCommand(id));
            if (orderResult.IsError)
            {
                return NotFound();
            }
            return Ok(orderResult.Value);
        }

        [HttpPut("Decline")]
        public async Task<ActionResult<OrderDTO>> Decline(Guid id)
        {
            var orderResult = await mediator.Send(new DeclineOrderCommand(id));
            if (orderResult.IsError)
            {
                return NotFound();
            }
            return Ok(orderResult.Value);
        }
    }
}
using HangryHub.OderService.UseCases.Order.Accept;
using HangryHub.OderService.UseCases.Order.CheckStatus;
using HangryHub.OderService.UseCases.Order.Create;
using HangryHub.OderService.UseCases.Order.Decline;
using HangryHub.OderService.UseCases.Order.DTOs;
using HangryHub.OderService.UseCases.Order.GetById;
using HangryHub.OderService.UseCases.Order.Ready;
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

        [HttpGet("Run")]
        public ActionResult<string> RunningTest()
        {
            return "Order Service is running";
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

        [HttpPut("Ready")]
        public async Task<ActionResult<OrderDTO>> Ready(Guid id)
        {
            var orderResult = await mediator.Send(new ReadyOrderCommand(id));
            if (orderResult.IsError)
            {
                return NotFound();
            }
            return Ok(orderResult.Value);
        }

        [HttpGet("Status")]
        public async Task<ActionResult<OrderStatusDTO>> CheckStatus(Guid id)
        {
            var orderResult = await mediator.Send(new CheckStatusOrderCommand(id));
            if (orderResult.IsError)
            {
                return NotFound();
            }
            return Ok(orderResult.Value);
        }
    }
}
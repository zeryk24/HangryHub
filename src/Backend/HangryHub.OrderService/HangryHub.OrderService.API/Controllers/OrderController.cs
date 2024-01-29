using HangryHub.OderService.UseCases.Order;
using HangryHub.OderService.UseCases.Order.Create;
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
    }
}
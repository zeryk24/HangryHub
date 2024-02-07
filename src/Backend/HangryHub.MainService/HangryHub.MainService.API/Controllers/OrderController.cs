using HangryHub.MainService.Application.Order.Producers.CreateOrder;
using HangryHub.MainService.Application.ShoppingCartAggregate.Query.GetAllShoppingCarts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HangryHub.MainService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("create")]
        public async Task CreateOrder(Guid orderGuid)
        {
            await _mediator.Send(new CreateOrderCommand() { ShoppingCartId = orderGuid });
        }
    }
}

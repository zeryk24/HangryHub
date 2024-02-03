using HangryHub.MainService.API.Models;
using HangryHub.MainService.Application.Restaurant.Command.CreateRestaurant;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HangryHub.MainService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : Controller
    {
        private readonly IMediator _mediator;

        public RestaurantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public IActionResult Create(RestaurantCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _mediator.Send(new CreateRestaurantCommand(model.Name, model.AddressLine1, model.AddressLine2, model.Country));
            return Ok();
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok();
        }
    }
}

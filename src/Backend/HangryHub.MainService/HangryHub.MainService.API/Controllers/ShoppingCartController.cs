﻿using HangryHub.MainService.API.Models;
using HangryHub.MainService.Application.Restaurant.Command.CreateRestaurant;
using HangryHub.MainService.Application.Restaurant.Query.GetRestaurantList;
using HangryHub.MainService.Application.ShoppingCartAggregate.Query.GetAllShoppingCarts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HangryHub.MainService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : Controller
    {
        private readonly IMediator _mediator;

        public ShoppingCartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /*[HttpPost("create")]
        public async Task<IActionResult> Create(RestaurantCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var restaurant = await _mediator.Send(new CreateRestaurantCommand()
            {
                Address = model.Address,
                Contact = model.Contact,
                Note = model.Note,
                Name = model.Name,
            });

            if (restaurant.IsError)
            {
                return BadRequest(restaurant);
            }

            return Ok(restaurant.Value);
        }*/

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var restaurants = await _mediator.Send(new GetAllShoppingCartsQuery());

            if (restaurants.IsError)
            {
                return BadRequest(restaurants);
            }

            return Ok(restaurants.Value);
        }

        /*[HttpPost("list-specified")]
        public async Task<IActionResult> ListSpecified(RestaurantFetchListModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var restaurants = await _mediator.Send(new GetRestaurantListQuery() { RestaurantIds = model.RestaurantGuids });

            if (restaurants.IsError)
            {
                return BadRequest(restaurants);
            }

            return Ok(restaurants.Value);
        }*/
    }
}

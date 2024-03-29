﻿using HangryHub.MainService.API.Models;
using HangryHub.MainService.Application.Restaurant.Command.CreateRestaurant;
using HangryHub.MainService.Application.Restaurant.Query.GetRestaurantList;
using HangryHub.MainService.Application.ShoppingCartAggregate.Command.AddItemToShoppingCart;
using HangryHub.MainService.Application.ShoppingCartAggregate.Command.CreateShoppingCart;
using HangryHub.MainService.Application.ShoppingCartAggregate.Command.RemoveItemFromShoppingCart;
using HangryHub.MainService.Application.ShoppingCartAggregate.Command.SetDeliveryAddress;
using HangryHub.MainService.Application.ShoppingCartAggregate.Query.GetAllShoppingCarts;
using HangryHub.MainService.Application.ShoppingCartAggregate.Query.GetUserShoppingCart;
using HangryHub.MainService.Domain.ShoppingCartAggregate.ValueObjects;
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

        [HttpPost("create-shopping-cart")]
        public async Task<IActionResult> CreateShoppingCart(CreateShoppingCartCommand model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cart = await _mediator.Send(model);

            if (cart.IsError)
            {
                return BadRequest(cart);
            }

            return Ok(cart.Value);
        }

        /*[HttpGet("get-shopping-cart")]
        public async Task<IActionResult> GetShoppingCart(Guid shoppingCartId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = new GetUserShoppingCartQuery();
            var cart = await _mediator.Send(model);

            if (cart.IsError)
            {
                return BadRequest(cart);
            }

            return Ok(cart.Value);
        }*/

        [HttpGet("get-shopping-cart")]
        public async Task<IActionResult> GetShoppingCart(Guid restaurantId, Guid customerId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = new GetUserShoppingCartQuery()
            { 
                CustomerId = customerId,
                RestaurantId = restaurantId,
            };

            var cart = await _mediator.Send(model);

            if (cart.IsError)
            {
                return BadRequest(cart);
            }

            return Ok(cart.Value);
        }

        [HttpDelete("remove-item-from-shopping-cart")]
        public async Task<IActionResult> DeleteItemFromShoppingCart(Guid shoppingCartId, Guid shoppingCartItemId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = new RemoveItemFromShoppingCartCommand()
            {
                ShoppingCartId = shoppingCartId,
                ShoppingCartItemId = shoppingCartItemId,
            };

            var cart = await _mediator.Send(model);

            if (cart.IsError)
            {
                return BadRequest(cart);
            }

            return Ok(cart.Value);
        }

        [HttpPost("add-item-to-shopping-cart")]
        public async Task<IActionResult> AddItemToShoppingCart(AddItemToShoppingCartCommand model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cart = await _mediator.Send(model);

            if (cart.IsError)
            {
                return BadRequest(cart);
            }

            return Ok(cart.Value);
        }

        [HttpPost("set-shopping-cart-delivery-address")]
        public async Task<IActionResult> AddItemToShoppingCart(SetDeliveryAddressCommand model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cart = await _mediator.Send(model);

            if (cart.IsError)
            {
                return BadRequest(cart);
            }

            return Ok(cart.Value);
        }

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
    }
}

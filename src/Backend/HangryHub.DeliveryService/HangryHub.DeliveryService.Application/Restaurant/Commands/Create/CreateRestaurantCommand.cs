using HangryHub.RestaurantService.Contracts.Restaurant.Messages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.DeliveryService.Application.Restaurant.Commands.Create
{
    public record CreateRestaurantCommand(RestaurantUpdateMessage Restaurant) : IRequest
    {
    }
}

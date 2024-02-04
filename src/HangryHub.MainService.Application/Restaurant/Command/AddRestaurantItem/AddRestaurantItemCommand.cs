using ErrorOr;
using HangryHub.MainService.Application.Restaurant.DTOs;
using HangryHub.MainService.Domain.RestaurantAggregate.Entities;
using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Application.Restaurant.Command.AddRestaurantItem
{
    public class AddRestaurantItemCommand : IRequest<ErrorOr<RestaurantDto>>
    {
        public required RestaurantId RestaurantId { get; set; }
        public required IEnumerable<RestaurantItemDto> RestaurantItems { get; set; }
    }
}

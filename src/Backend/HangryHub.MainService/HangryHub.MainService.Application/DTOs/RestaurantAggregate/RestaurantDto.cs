using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Application.DTOs.RestaurantAggregate
{
    public class RestaurantDto
    {
        public required RestaurantId Id { get; set; }
        public required string Name { get; set; }
        public required RestaurantDetailDto Detail { get; set; }
        public required List<RestaurantItemDto> Items { get; set; }
    }
}

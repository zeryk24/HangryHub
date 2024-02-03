using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Domain.RestaurantAggregate.Entities
{
    public class RestaurantLocation
    {
        public required string AddressLine1 { get; set; }
        public required string AddressLine2 { get; set; }
        public required string Country { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Application.Restaurant.DTOs
{
    public class RestaurantDetailDto
    {
        public required string Address { get; set; }
        public required string Contact { get; set; }
        public required string Note { get; set; }
    }
}

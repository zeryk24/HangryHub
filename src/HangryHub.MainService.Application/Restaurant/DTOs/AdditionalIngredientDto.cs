using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Application.Restaurant.DTOs
{
    public class AdditionalIngredientDto
    {
        public required AdditionalIngredientId Id { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
    }
}

using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Application.DTOs.RestaurantAggregate
{
    public class IngredientDto
    {
        public required IngredientId Id { get; set; }
        public required string Name { get; set; }
    }
}

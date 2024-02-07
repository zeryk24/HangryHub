using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Application.Restaurant.DTOs.RestaurantAggregate
{
    public class RestaurantItemDto
    {
        public required RestaurantItemId Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public required List<IngredientDto> Ingredients { get; set; }
        public required List<AdditionalIngredientDto> AdditionalIngredients { get; set; }
    }
}

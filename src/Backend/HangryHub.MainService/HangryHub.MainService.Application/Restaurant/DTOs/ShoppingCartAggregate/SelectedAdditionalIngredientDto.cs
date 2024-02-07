using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Application.Restaurant.DTOs.ShoppingCartAggregate
{
    public class SelectedAdditionalIngredientDto
    {
        public required AdditionalIngredientId AdditionalIngredientId { get; set; }
        public required string Name { get; set; }
        public required int Quantity { get; set; }
        public required decimal Price { get; set; }
    }
}

using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Application.Restaurant.DTOs.ShoppingCartAggregate
{
    public class ShoppingCartItemDto
    {
        public required RestaurantItemId RestaurantItemId { get; set; }
        public required string ItemName { get; set; }
        public required string ItemDescription { get; set; }
        public required decimal Price { get; set; }
        public required int Quantity { get; set; }
        public List<SelectedAdditionalIngredientDto> SelectedAdditionalIngredients { get; set; } = new ();
    }
}

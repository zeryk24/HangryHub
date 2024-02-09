using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Application.DTOs.ShoppingCartAggregate.Request
{
    public class ShoppingCartItemAdditionDTO
    {
        public required Guid RestaurantItemId { get; set; }

        public required int RestaurantItemQuantity { get; set; }

        public List<ShoppingCartItemAdditionalIngredientDTO> AdditionalIngredients { get; set; } = new();
    }
}

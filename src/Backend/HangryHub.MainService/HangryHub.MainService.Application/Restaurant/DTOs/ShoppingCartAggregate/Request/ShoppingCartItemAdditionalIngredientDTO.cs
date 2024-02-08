using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Application.Restaurant.DTOs.ShoppingCartAggregate.Request
{
    public class ShoppingCartItemAdditionalIngredientDTO
    {
        public required Guid AdditionalIngredientId { get; set; }

        public required int AdditionalIngredientQuantity { get; set; }
    }
}

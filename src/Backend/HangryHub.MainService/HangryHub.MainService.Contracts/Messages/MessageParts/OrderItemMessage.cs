using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Contracts.Messages.MessageParts
{
    public record OrderItemMessage
    {
        public required Guid RestaurantItemId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required int Quantity { get; set; }
        public required decimal Price { get; set; }
        public required List<AdditionalIngredientMessage> AdditionalIngredients { get; set; } = new List<AdditionalIngredientMessage>();
    }
}

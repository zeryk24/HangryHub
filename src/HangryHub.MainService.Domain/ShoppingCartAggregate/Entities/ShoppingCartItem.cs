using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using HangryHub.MainService.Domain.ShoppingCartAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Domain.ShoppingCartAggregate.Entities
{
    public class ShoppingCartItem : Entity<ShoppingCartItemId>
    {
        public required ShoppingCartId ShoppingCartId { get; set; }

        // do not reference this as an Object. It would go against DDD/CA
        public required RestaurantItemId RestaurantItemId { get; set; }

        public required string ItemName { get; set; }
        public required string ItemDescription { get; set; }
        public required decimal Price { get; set; }
        public required int Quantity { get; set; }

        private ShoppingCartItem() { }

        public ShoppingCartItem(ShoppingCartItemId id) : base(id)
        {
        }

        public virtual ShoppingCart? ShoppingCart { get; set; }

        public virtual IEnumerable<SelectedAdditionalIngredient> SelectedAdditionalIngredients { get; set; }
    }
}

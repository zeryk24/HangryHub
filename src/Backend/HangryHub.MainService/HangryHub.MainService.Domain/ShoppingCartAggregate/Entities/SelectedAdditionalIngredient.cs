using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using HangryHub.MainService.Domain.ShoppingCartAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Domain.ShoppingCartAggregate.Entities
{
    public class SelectedAdditionalIngredient : Entity<SelectedAdditionalIngredientId>
    {
        public ShoppingCartItemId ShoppingCartItemId { get; set; }

        // do not reference this as an Object. It would go against DDD/CA
        public AdditionalIngredientId AdditionalIngredientId { get; set; }

        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        private SelectedAdditionalIngredient() { }

        public SelectedAdditionalIngredient(SelectedAdditionalIngredientId id) : base(id)
        {
        }

        public virtual ShoppingCartItem? ShoppingCartItem { get; set; }
    }
}

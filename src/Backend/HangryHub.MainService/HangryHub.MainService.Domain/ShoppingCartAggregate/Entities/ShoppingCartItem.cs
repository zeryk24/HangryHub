﻿using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
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
        public ShoppingCartId ShoppingCartId { get; set; }

        // do not reference this as an Object. It would go against DDD/CA
        public RestaurantItemId RestaurantItemId { get; set; }

        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        private ShoppingCartItem() { }

        public ShoppingCartItem(ShoppingCartItemId id) : base(id)
        {
        }

        public virtual ShoppingCart? ShoppingCart { get; set; }

        public virtual IEnumerable<SelectedAdditionalIngredient> SelectedAdditionalIngredients { get; set; }

        /*public override bool Equals(object? obj)
        {
            if (obj is not ShoppingCartItem item)
            {
                return false;
            }

            var left = SelectedAdditionalIngredients.OrderBy(a => a.Name).ToList();
            var right = item.SelectedAdditionalIngredients.OrderBy(a => a.Name).ToList();
            var leqr = left.SequenceEqual(right);

            return ShoppingCartId.Value == item.ShoppingCartId.Value &&
                   RestaurantItemId.Value == item.RestaurantItemId.Value &&
                   leqr;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), ShoppingCartId, RestaurantItemId, SelectedAdditionalIngredients);
        }*/
    }
}

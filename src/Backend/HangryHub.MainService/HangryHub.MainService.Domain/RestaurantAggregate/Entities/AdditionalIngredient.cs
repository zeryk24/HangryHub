using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Domain.RestaurantAggregate.Entities
{
    public class AdditionalIngredient : Entity<AdditionalIngredientId>
    {
        public required string Name { get; set; }

        public required RestaurantItemId RestaurantItemId { get; set; }

        public virtual RestaurantItem RestaurantItem { get; set; }

        public required decimal Price { get; set; }

        private AdditionalIngredient() { }

        public AdditionalIngredient(AdditionalIngredientId id) : base(id)
        {
        }
    }
}

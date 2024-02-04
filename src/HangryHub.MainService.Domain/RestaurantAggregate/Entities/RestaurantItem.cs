using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;

namespace HangryHub.MainService.Domain.RestaurantAggregate.Entities
{
    public class RestaurantItem : Entity<RestaurantItemId>
    {
        public required RestaurantId RestaurantId { get; set; }
        public virtual Restaurant? Restaurant { get; set; }

        private RestaurantItem() { }

        public RestaurantItem(RestaurantItemId id) : base(id)
        {
        }

        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }

        public virtual IEnumerable<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public virtual IEnumerable<AdditionalIngredient> AdditionalIngredients { get; set; } = new List<AdditionalIngredient>();
    }
}

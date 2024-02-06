using HangryHub.OrderService.Core.Common;
using HangryHub.OrderService.Core.OrderAggregate.Entities.IngredientEntity.ValueObjects;

namespace HangryHub.OrderService.Core.OrderAggregate.Entities.IngredientEntity
{
    public class ExtraIngredient : Entity<Guid>
    {
        public IngredientName Name { get; private set; }
        public IngredientQuantity Quantity { get; private set; }

        public ExtraIngredient(IngredientName name, IngredientQuantity quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        private ExtraIngredient()
        {
        }
    }
}

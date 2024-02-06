using HangryHub.OrderService.Core.Common;

namespace HangryHub.OrderService.Core.OrderAggregate.Entities.IngredientEntity.ValueObjects
{
    public class IngredientQuantity : ValueObject
    {
        public int Quantity { get; private set; }

        public IngredientQuantity(int quantity)
        {
            Quantity = quantity;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Quantity;
        }
    }
}

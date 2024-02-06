using HangryHub.OrderService.Core.Common;

namespace HangryHub.OrderService.Core.OrderAggregate.Entities.IngredientEntity.ValueObjects
{
    public class IngredientName : ValueObject
    {
        public string Name { get; private set; }

        public IngredientName(string name)
        {
            Name = name;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}

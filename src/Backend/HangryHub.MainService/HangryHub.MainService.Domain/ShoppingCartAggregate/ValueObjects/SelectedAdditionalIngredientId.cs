using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Domain.ShoppingCartAggregate.ValueObjects
{
    public class SelectedAdditionalIngredientId(Guid value) : ValueObject
    {
        public Guid Value { get; set; } = value;

        public static SelectedAdditionalIngredientId CreateUnique() => new(Guid.NewGuid());
        public static SelectedAdditionalIngredientId Create(Guid value) => new(value);

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

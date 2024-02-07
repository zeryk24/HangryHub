using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Domain.ShoppingCartAggregate.ValueObjects
{
    public class ShoppingCartId(Guid value) : ValueObject
    {
        public Guid Value { get; set; } = value;

        public static ShoppingCartId CreateUnique() => new(Guid.NewGuid());
        public static ShoppingCartId Create(Guid value) => new(value);

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

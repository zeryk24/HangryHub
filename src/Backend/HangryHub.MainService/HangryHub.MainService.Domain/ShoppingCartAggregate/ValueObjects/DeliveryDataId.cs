using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Domain.ShoppingCartAggregate.ValueObjects
{
    public class DeliveryDataId(Guid value) : ValueObject
    {
        public Guid Value { get; set; } = value;

        public static DeliveryDataId CreateUnique() => new(Guid.NewGuid());
        public static DeliveryDataId Create(Guid value) => new(value);

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

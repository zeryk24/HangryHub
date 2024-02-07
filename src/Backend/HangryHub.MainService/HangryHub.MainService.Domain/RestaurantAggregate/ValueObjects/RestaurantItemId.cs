using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects
{
    public class RestaurantItemId(Guid value) : ValueObject
    {
        public Guid Value { get; set; } = value;

        public static RestaurantItemId CreateUnique() => new(Guid.NewGuid());
        public static RestaurantItemId Create(Guid value) => new(value);

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects
{
    public class RestaurantId(Guid value) : ValueObject
    {
        public Guid Value { get; set; } = value;

        public static RestaurantId CreateUnique() => new(Guid.NewGuid());
        public static RestaurantId Create(Guid value) => new(value);

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects
{
    public class RestaurantLocationId : ValueObject
    {
        public Guid Value { get; set; }

        public RestaurantLocationId(Guid value)
        {
            Value = value;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

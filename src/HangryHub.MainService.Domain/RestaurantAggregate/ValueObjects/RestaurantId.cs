using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects
{
    public class RestaurantId : ValueObject
    {
        public Guid Value { get; set; }

        public RestaurantId(Guid value)
        {
            Value = value;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

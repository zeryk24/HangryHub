using HangryHub.OrderService.Core.Common;

namespace HangryHub.OrderService.Core.OrderAggregate.ValueObjects
{
    public class Price : ValueObject
    {
        public double Euro { get; private set; }

        public Price(double euro)
        {
            Euro = euro;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Euro;
        }
    }
}

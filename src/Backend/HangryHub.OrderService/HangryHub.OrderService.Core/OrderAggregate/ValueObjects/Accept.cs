using HangryHub.OrderService.Core.Common;

namespace HangryHub.OrderService.Core.OrderAggregate.ValueObjects
{
    public class Accept : ValueObject
    {
        public bool IsAccepted { get; private set; }
        public DateTime? Date { get; private set; }

        public Accept(bool isAccepted, DateTime? date)
        {
            IsAccepted = isAccepted;
            Date = date;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return IsAccepted;
            yield return Date;
        }

        public void AcceptOrder()
        {
            IsAccepted = true;
            Date = DateTime.Now;
        }
    }
}

using HangryHub.OrderService.Core.Common;

namespace HangryHub.OrderService.Core.OrderAggregate.ValueObjects
{
    public class Ready : ValueObject
    {
        public bool IsReady { get; private set; }
        public DateTime? Date { get; private set; }

        public Ready(bool isReady, DateTime? date)
        {
            IsReady = isReady;
            Date = date;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return IsReady;
            yield return Date;
        }

        public void OrderIsReady()
        {
            IsReady = true;
            Date = DateTime.Now;
        }
    }
}

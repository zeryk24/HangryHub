using HangryHub.OrderService.Core.Common;

namespace HangryHub.OrderService.Core.OrderAggregate.ValueObjects
{
    public class Decline : ValueObject
    {
        public bool IsDeclined { get; set; }
        public DateTime? Date { get; set; }

        public Decline(bool isDeclined, DateTime? date)
        
        {
            IsDeclined=isDeclined;
            Date=date;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return IsDeclined;
            yield return Date;
        }

        public void DeclineOrder()
        {
            IsDeclined = true;
            Date = DateTime.Now;
        }
    }
}

using HangryHub.OrderService.Core.Common;
using HangryHub.OrderService.Core.OrderAggregate.ValueObjects;

namespace HangryHub.OrderService.Core.OrderAggregate
{
    public class Order : AggregateRoot<Guid>
    {
        public Price PriceEuro { get; private set; }

        public Order(Price euro)
        {
            PriceEuro = euro;
        }

        private Order() : base(Guid.Empty) { }
    }
}

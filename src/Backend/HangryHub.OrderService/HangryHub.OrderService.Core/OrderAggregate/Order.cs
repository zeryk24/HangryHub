using HangryHub.OrderService.Core.Common;
using HangryHub.OrderService.Core.OrderAggregate.ValueObjects;

namespace HangryHub.OrderService.Core.OrderAggregate
{
    public class Order : AggregateRoot<Guid>
    {
        public Price PriceEuro { get; private set; }
        public Accept OrderAccepted { get; private set; }
        public Decline OrderDeclined { get; private set; }
        public Ready OrderReady { get; private set; }

        public Order(Price euro, Accept orderAccepted, Decline orderDeclines, Ready orderReady)
        {
            PriceEuro = euro;
            OrderAccepted = orderAccepted;
            OrderDeclined = orderDeclines;
            OrderReady = orderReady;
        }

        private Order() { }

        public void AcceptOrder()
        {
            OrderAccepted.AcceptOrder();
        }

        public void DeclineOrder()
        {
            OrderDeclined.DeclineOrder();
        }

        public void OrderIsReady()
        {
            OrderReady.OrderIsReady();
        }
    }
}

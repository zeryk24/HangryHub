using HangryHub.OrderService.Core.Common;
using HangryHub.OrderService.Core.OrderAggregate.Entities.CouponEntity;
using HangryHub.OrderService.Core.OrderAggregate.Entities.OrderItemEntity;
using HangryHub.OrderService.Core.OrderAggregate.Enums;
using HangryHub.OrderService.Core.OrderAggregate.ValueObjects;

namespace HangryHub.OrderService.Core.OrderAggregate
{
    public class Order : AggregateRoot<Guid>
    {
        public Price PriceEuro { get; private set; }
        public Accept OrderAccepted { get; private set; }
        public Decline OrderDeclined { get; private set; }
        public Ready OrderReady { get; private set; }
        public OrderState OrderState { get; private set; }
        public UserId UserId { get; set; }
        public Coupon? Coupon { get; private set; }
        public List<OrderItem> Items { get; set; }

        public Order(Price euro, Accept orderAccepted, Decline orderDeclines, Ready orderReady, Coupon? coupon, UserId userId, List<OrderItem> items)
        {
            PriceEuro = euro;
            OrderAccepted = orderAccepted;
            OrderDeclined = orderDeclines;
            OrderReady = orderReady;
            OrderState = OrderState.NotAccepted;
            Coupon = coupon;
            UserId = userId;
            Items = items;
        }

        private Order() { }

        public void AcceptOrder()
        {
            OrderAccepted.AcceptOrder();
            OrderState = OrderState.Accepted;
        }

        public void DeclineOrder()
        {
            OrderDeclined.DeclineOrder();
            OrderState = OrderState.Declined;
        }

        public void OrderIsReady()
        {
            OrderReady.OrderIsReady();
            OrderState = OrderState.Ready;
        }
    }
}

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
        public OrderState OrderState { get; private set; }
        public RestaurantId RestaurantId { get; private set; }
        public UserId UserId { get; private set; }
        public Coupon? Coupon { get; private set; }
        public List<OrderItem> Items { get; private set; }

        public Order(Price euro, Coupon? coupon, UserId userId, List<OrderItem> items, RestaurantId restaurantId)
        {
            PriceEuro = euro;
            OrderState = OrderState.NotAccepted;
            Coupon = coupon;
            UserId = userId;
            Items = items;
            RestaurantId = restaurantId;
        }

        private Order() { }

        public void AcceptOrder()
        {
            if (OrderState == OrderState.Accepted)
            {
                throw new ArgumentException("Order is already accepted");
            }
            
            OrderState = OrderState.Accepted;
        }

        public void DeclineOrder()
        {
            if (OrderState == OrderState.Declined)
            {
                throw new ArgumentException("Order is already declined");
            }

            OrderState = OrderState.Declined;
        }

        public void OrderIsReady()
        {
            if (OrderState == OrderState.Declined || OrderState == OrderState.NotAccepted)
            {
                throw new ArgumentException("Order is declined and can't be mark as ready");
            }

            OrderState = OrderState.Ready;
        }
    }
}

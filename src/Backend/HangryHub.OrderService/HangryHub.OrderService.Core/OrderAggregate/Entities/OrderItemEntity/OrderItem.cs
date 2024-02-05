using HangryHub.OrderService.Core.Common;
using HangryHub.OrderService.Core.OrderAggregate.Entities.OrderItemEntity.ValueObjects;

namespace HangryHub.OrderService.Core.OrderAggregate.Entities.OrderItemEntity
{
    public class OrderItem : Entity<Guid>
    {
        public RestaurantItemId RestaurantItemId { get; private set; }
        public ItemName Name { get; private set; }
        public ItemQuantity Quantity { get; private set; }
        public ItemPrice Price { get; private set; }

        public OrderItem(RestaurantItemId restaurantItemId, ItemName name, ItemQuantity quantity, ItemPrice price)
        {
            RestaurantItemId = restaurantItemId;
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        private OrderItem()
        { }
    }
}

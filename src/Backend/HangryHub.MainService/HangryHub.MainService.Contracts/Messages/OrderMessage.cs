using HangryHub.MainService.Contracts.Messages.MessageParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Contracts.Messages
{
    /*
     * [OrderData]
        --> `Order`
        -----> UserId
        -----> RestaurantId
        --------> RestaurantData
        -----> `OrderItem`
        --------> RestaurantItemId
        --------> Name
        --------> Quantity
        --------> Price (per item)
        --------> `AdditionalIngredients`
        ------------> AdditionalIngredient
        ------------> Name
        ------------> Quantity
        -----> `Coupon`
        --------> CouponId
        --------> Name
        --------> Price (per item)
        -----> `DeliveryData`
        --------> DeliveryLocation
        --------> Note
        --------> UserContact
        -----> Subtotal
     */
    public record OrderMessage
    {
        public required Guid UserId { get; set; }
        public required Guid RestaurantId { get; set; }
        public required RestaurantDataMessage RestaurantData { get; set; }
        public required List<OrderItemMessage> Items { get; set; } = new List<OrderItemMessage>();
        public required List<CouponMessage> Coupons { get; set; } = new List<CouponMessage>();
        public required DeliveryDataMessage DeliveryData { get; set; }
        public required decimal Subtotal { get; set; }
    }
}

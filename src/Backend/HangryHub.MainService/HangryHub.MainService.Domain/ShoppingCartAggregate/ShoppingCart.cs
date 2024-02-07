using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using HangryHub.MainService.Domain.ShoppingCartAggregate.Entities;
using HangryHub.MainService.Domain.ShoppingCartAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Domain.ShoppingCartAggregate
{
    public class ShoppingCart : AggregateRoot<ShoppingCartId>
    {
        public required CustomerId CustomerId { get; set; }
        public required RestaurantId RestaurantId { get; set; }

        public DeliveryDataId? SelectedDeliveryDataId { get; set; } = null;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public required DateTime LastUpdatedDate { get; set; }

        private ShoppingCart() { }

        public ShoppingCart(ShoppingCartId id) : base(id)
        {
        }

        public virtual DeliveryData? SelectedDeliveryData { get; set; }
        public virtual IEnumerable<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
    }
}

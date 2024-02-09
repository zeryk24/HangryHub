using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using HangryHub.MainService.Domain.ShoppingCartAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Application.DTOs.ShoppingCartAggregate
{
    public class ShoppingCartDto
    {
        public required ShoppingCartId Id { get; set; }
        public required CustomerId CustomerId { get; set; }
        public required RestaurantId RestaurantId { get; set; }
        public DeliveryDataDto? SelectedDeliveryData { get; set; }
        public required List<ShoppingCartItemDto> Items { get; set; } = new();
        public required bool IsActive { get; set; }
        public required DateTime CreatedDate { get; set; }
        public required DateTime LastUpdatedDate { get; set; }
    }
}

using HangryHub.MainService.Domain.ShoppingCartAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Application.DTOs.ShoppingCartAggregate
{
    public class DeliveryDataDto
    {
        public required CustomerId CustomerId { get; set; }
        public required string DeliveryLocation { get; set; }
        public required string Contact { get; set; }
        public required string Note { get; set; }
        public required bool IsActive { get; set; }
    }
}

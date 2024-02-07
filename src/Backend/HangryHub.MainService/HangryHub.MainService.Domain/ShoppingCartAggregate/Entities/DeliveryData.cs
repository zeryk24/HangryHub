using HangryHub.MainService.Domain.ShoppingCartAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Domain.ShoppingCartAggregate.Entities
{
    public class DeliveryData : Entity<DeliveryDataId>
    {
        public required CustomerId CustomerId { get; set; }

        public required string DeliveryLocation { get; set; }

        public required string Contact { get; set; }

        public required string Note { get; set; }

        public bool IsActive { get; set; } = true;

        private DeliveryData() { }

        public DeliveryData(DeliveryDataId id) : base(id)
        {
        }
    }
}

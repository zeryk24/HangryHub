using HangryHub.DeliveryService.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.DeliveryService.Domain.Delivery
{
    public class Delivery : AggregateRoot
    {
        public string Name { get; set; }


        public Delivery(Guid id, string name) : base(id)
        {
            Name = name;
        }
    }
}

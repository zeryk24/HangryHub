using HangryHub.DeliveryService.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.DeliveryService.Domain.RestaurantAggregate
{
    public class Restaurant : AggregateRoot
    {

        public string Name { get; private set; }
        public string Contact { get; private set; }
        public string Location { get; private set; }

        public Restaurant(Guid id, string name, string contact, string location) : base(id)
        {
            Contact = contact;
            Location = location;
            Name = name;
        }
    }
}

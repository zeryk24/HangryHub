using HangryHub.DeliveryService.Domain.Common;
using HangryHub.DeliveryService.Domain.DeliveryAggregate.ValueObjects;

namespace HangryHub.DeliveryService.Domain.DeliveryAggregate.Entities
{
    public class Customer : Entity
    {
        public CustomerId Id { get; private set; }
        public CustomerContact Contact { get; private set; }
        public CustomerDeliveryLocation DeliveryLocation { get; private set; }

        public Customer(CustomerId id, CustomerContact contact, CustomerDeliveryLocation deliveryLocation)
        {
            Id = id;
            Contact = contact;
            DeliveryLocation = deliveryLocation;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Customer() 
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }
    }
}
